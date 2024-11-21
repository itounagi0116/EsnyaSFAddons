using UdonSharp;
using UdonToolkit;
using UnityEngine;
using VRC.Udon.Common.Interfaces;

namespace EsnyaSFAddons.DFUNC
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class DFUNC_SendCustomEvent : DFUNC_Base
    {
        [System.Serializable]
        public class EventTrigger
        {
            public enum TriggerType
            {
                TriggerPress,
                TriggerRelease,
                KeyboardInput,
                // 必要に応じて他のイベントを追加
            }

            public TriggerType triggerType;
            [Popup("behaviour", "@target")] public string eventName;
        }

        public string targetGameObjectName;
        public bool networked;
        [HideIf("@!networked")] public NetworkEventTarget networkEventTarget;
        public EventTrigger[] eventTriggers;

        private UdonSharpBehaviour _target;

        private UdonSharpBehaviour target
        {
            get
            {
                if (!_target)
                {
                    var gameObject = GameObject.Find(targetGameObjectName);
                    if (gameObject)
                    {
                        _target = (UdonSharpBehaviour)gameObject.GetComponent(typeof(UdonSharpBehaviour));
                    }
                }
                return _target;
            }
        }

        public override void DFUNC_TriggerPressed()
        {
            _SendEvent(EventTrigger.TriggerType.TriggerPress);
        }

        public override void DFUNC_TriggerReleased()
        {
            _SendEvent(EventTrigger.TriggerType.TriggerRelease);
        }

        public void KeyboardInput()
        {
            _SendEvent(EventTrigger.TriggerType.KeyboardInput);
        }

        private void _SendEvent(EventTrigger.TriggerType triggerType)
        {
            if (string.IsNullOrEmpty(targetGameObjectName))
            {
                Debug.LogError("Target GameObject Name is empty.");
                return;
            }

            if (!target)
            {
                Debug.LogError($"Target GameObject '{targetGameObjectName}' not found or does not have a UdonSharpBehaviour component.");
                return;
            }

            foreach (var trigger in eventTriggers)
            {
                if (trigger.triggerType == triggerType)
                {
                    if (!string.IsNullOrEmpty(trigger.eventName))
                    {
                        if (networked)
                        {
                            target.SendCustomNetworkEvent(networkEventTarget, trigger.eventName);
                        }
                        else
                        {
                            target.SendCustomEvent(trigger.eventName);
                        }
                    }
                    else
                    {
                        Debug.LogError("Event name is empty.");
                    }
                }
            }
        }
    }
}
