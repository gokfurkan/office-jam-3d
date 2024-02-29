﻿using UnityEngine;

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
                chairController.StartMoveSequence();
            }
        }
        
        public void OnChairMoveSuccess()
        {
            chairController.ResetMoveSequence();
            
            deskController.OnSuccessSequence();
            officerController.OnSuccessSequence();
            chairController.OnSuccessSequence();
            
            BusSystem.CallSuccessMoveSequence();
        }

        public void OnChairMoveFail(GameObject collisionChair)
        {
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