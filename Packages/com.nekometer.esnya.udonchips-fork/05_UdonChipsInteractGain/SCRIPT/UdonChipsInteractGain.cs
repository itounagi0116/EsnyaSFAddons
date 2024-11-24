
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UCS
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class UdonChipsInteractGain : UdonSharpBehaviour
    {
        [Header("----------------------System-------------------------")]
        [SerializeField] private AudioSource audioSource_ButtonHit;
        private UdonChips udonChips;
        [Space(20)]
        [Header("----------------------Reward-------------------------")]
        [SerializeField] private float moneyReward = 0.2f;


        void Start()
        {
            udonChips = UdonChips.GetInstance();
        }

        public override void Interact()
        {
            ButtonPush();
        }


        private void ButtonPush()
        {
            udonChips.money = udonChips.money + moneyReward;

            if (audioSource_ButtonHit != null)
            {
                audioSource_ButtonHit.Play();
            }
        }
    }
}