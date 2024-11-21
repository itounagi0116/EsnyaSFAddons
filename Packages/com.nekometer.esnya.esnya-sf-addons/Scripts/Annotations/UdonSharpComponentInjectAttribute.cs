using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UdonSharp;
using UdonToolkit;

#if UNITY_EDITOR
using UnityEditor;
using VRC.SDKBase.Editor.BuildPipeline;
#endif

namespace EsnyaSFAddons.Annotations
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
#if UNITY_EDITOR
    public class UdonSharpComponentInjectAttribute : UTPropertyAttribute
#else
    public class UdonSharpComponentInjectAttribute : System.Attribute
#endif
    {
#if !COMPILER_UDONSHARP && UNITY_EDITOR
        private static Dictionary<Type, UdonSharpBehaviour[]> componentCache = new Dictionary<Type, UdonSharpBehaviour[]>();

        public override void BeforeGUI(SerializedProperty property)
        {
            if (!property.isArray) EditorGUILayout.BeginHorizontal();
        }

        public override void AfterGUI(SerializedProperty property)
        {
            if (GUILayout.Button("Force Update", GUILayout.ExpandWidth(false)))
            {
                InjectComponents(property.serializedObject.targetObject as Component);
            }
            if (!property.isArray) EditorGUILayout.EndHorizontal();
            EditorGUILayout.HelpBox("Auto injected by script.", MessageType.Info);
        }

        public static void InjectComponents(Component targetComponent)
        {
            if (targetComponent == null) return;

            var gameObject = targetComponent.gameObject;
            var udonSharpBehaviour = targetComponent as UdonSharpBehaviour;
            if (udonSharpBehaviour == null) return;

            var type = udonSharpBehaviour.GetType();
            var fields = type.GetFields().Where(f => f.GetCustomAttribute<UdonSharpComponentInjectAttribute>() != null).ToArray();

            foreach (var field in fields)
            {
                var isArray = field.FieldType.IsArray;
                var valueType = isArray ? field.FieldType.GetElementType() : field.FieldType;
                var isComponent = valueType.IsSubclassOf(typeof(UdonSharpBehaviour));

                if (isArray)
                {
                    var components = FindObjectsOfType(valueType);
                    if (components != null)
                    {
                        var value = field.FieldType.GetConstructor(new[] { typeof(int) }).Invoke(new object[] { components.Length });
                        Array.Copy(components, value as Array, components.Length);
                        field.SetValue(udonSharpBehaviour, value);
                    }
                    else
                    {
                        Debug.LogError($"Failed to find components of type {valueType}");
                    }
                }
                else
                {
                    if (isComponent)
                    {
                        if (!componentCache.TryGetValue(valueType, out var cachedComponents))
                        {
                            cachedComponents = FindObjectsOfType(valueType).Cast<UdonSharpBehaviour>().ToArray();
                            componentCache[valueType] = cachedComponents;
                        }
                        field.SetValue(udonSharpBehaviour, cachedComponents.FirstOrDefault());
                    }
                    else
                    {
                        var component = FindObjectsOfType(valueType).FirstOrDefault();
                        if (component != null)
                        {
                            field.SetValue(udonSharpBehaviour, component);
                        }
                        else
                        {
                            Debug.LogError($"Failed to find component of type {valueType}");
                        }
                    }
                }
            }

            EditorUtility.SetDirty(udonSharpBehaviour);
        }

        [InitializeOnLoadMethod]
        public static void InitializeOnLoad()
        {
            EditorApplication.playModeStateChanged += (PlayModeStateChange e) =>
            {
                if (e == PlayModeStateChange.EnteredPlayMode)
                {
                    foreach (var udonSharpBehaviour in FindObjectsOfType<UdonSharpBehaviour>())
                    {
                        InjectComponents(udonSharpBehaviour);
                    }
                }
            };
        }

        public class BuildCallback : IVRCSDKBuildRequestedCallback
        {
            public int callbackOrder => 10;

            public bool OnBuildRequested(VRCSDKRequestedBuildType requestedBuildType)
            {
                foreach (var udonSharpBehaviour in FindObjectsOfType<UdonSharpBehaviour>())
                {
                    InjectComponents(udonSharpBehaviour);
                }
                return true;
            }
        }
#endif
    }
}
