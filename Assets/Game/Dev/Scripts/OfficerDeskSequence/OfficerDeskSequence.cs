using UnityEngine;

namespace Game.Dev.Scripts
{
    public class OfficerDeskSequence : MonoBehaviour
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
        
        private void ControlSelectSequence(GameObject selected)
        {
            if (selected == chairController.gameObject)
            {
                chairController.StartMoveSequence();
            }
        }
        
        public void OnChairMoveSuccess()
        {
            chairController.ResetMoveSequence();
            
            deskController.OnOfficerSitDesk();
            officerController.OnOfficerSitDesk();
            chairController.OnOfficerSitDesk();
            
            BusSystem.CallSuccessMoveSequence();
        }

        public void OnChairMoveFail()
        {
            chairController.ResetMoveSequence();
            chairController.ResetPosition();
        }
    }
}