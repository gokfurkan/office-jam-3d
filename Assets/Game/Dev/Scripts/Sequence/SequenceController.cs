using MoreMountains.NiceVibrations;
using Template.Scripts;
using UnityEngine;

namespace Game.Dev.Scripts.Sequence
{
    public class SequenceController : MonoBehaviour
    {
        public ChairController chairController;
        public DeskController deskController;
        public OfficerController officerController;
        
        private void OnEnable()
        {
            BusSystem.OnSelectChair += ControlSelectSequence;
        }

        private void OnDisable()
        {
            BusSystem.OnSelectChair -= ControlSelectSequence;
        }

        private void Start()
        {
            officerController.InitOfficer();
            chairController.InitChair();
            deskController.InitDesk();
        }

        private void ControlSelectSequence(GameObject selected)
        {
            if (selected == chairController.gameObject)
            {
                AudioManager.instance.Play(AudioType.Move);
                HapticManager.instance.PlayHaptic(HapticTypes.LightImpact);
                
                chairController.StartMoveSequence();
            }
        }
        
        public void OnChairMoveSuccess()
        {
            HapticManager.instance.PlayHaptic(HapticTypes.MediumImpact);
            AudioManager.instance.Play(AudioType.SuccessMove);
            
            chairController.ResetMoveSequence();
            
            deskController.OnSuccessSequence();
            officerController.OnSuccessSequence();
            chairController.OnSuccessSequence();
            
            BusSystem.CallSuccessMoveSequence();
        }

        public void OnChairMoveFail(GameObject collisionChair)
        {
            HapticManager.instance.PlayHaptic(HapticTypes.HeavyImpact);
            AudioManager.instance.Play(AudioType.FailMove);
            
            chairController.ResetMoveSequence();
            chairController.ResetPosition();
            chairController.OnFailSequence();
            
            officerController.OnFailSequence();
            
            var collChairController = collisionChair.GetComponent<ChairController>();
            if (collChairController != null)
            {
                collChairController.OnFailSequence();
            }

            BusSystem.CallFailMoveSequence();
        }
    }
}