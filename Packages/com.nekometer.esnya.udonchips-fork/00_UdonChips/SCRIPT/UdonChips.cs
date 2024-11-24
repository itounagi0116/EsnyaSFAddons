using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UCS
{
	[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
	public class UdonChips : UdonSharpBehaviour
	{
		[Tooltip("現在の所持金（初期所持金）")]
		public float money = 1000;

		public string format = "$ {0:F0}";

		public static UdonChips GetInstance()
		{
			var o = GameObject.Find(nameof(UdonChips));
			return o ? o.GetComponent<UdonChips>() : null;
		}
	}
}
