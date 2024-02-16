using System;
using UnityEngine;

namespace Game.Dev.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public Transform sequenceParent;

        private int successSequenceAmount;
        private int totalSequenceAmount;

        private void OnEnable()
        {
            BusSystem.OnSuccessMoveSequence += OnSuccessSequence;
        }

        private void OnDisable()
        {
            BusSystem.OnSuccessMoveSequence -= OnSuccessSequence;
        }

        private void Start()
        {
            totalSequenceAmount = sequenceParent.childCount;
        }

        private void OnSuccessSequence()
        {
            successSequenceAmount++;
            if (successSequenceAmount == totalSequenceAmount)
            {
                BusSystem.CallLevelEnd(true);
            }
        }
    }
}