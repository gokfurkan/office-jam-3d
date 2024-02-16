using System;
using DG.Tweening;
using Game.Dev.Scripts.Scriptables;
using Template.Scripts;
using UnityEngine;

namespace Game.Dev.Scripts
{
    public class ChairController : MonoBehaviour
    {
        [SerializeField] private ChairSettings chairSettings;
        [SerializeField] private SequenceController sequenceController;
        [SerializeField] private Rigidbody rb;

        private bool canMove;
        private bool isChairMoving;
        private Tween moveTween;
        private float initialChairPositionZ;
        
        private void Start()
        {
            InitChair();
        }

        private void InitChair()
        {
            canMove = true;
            rb.isKinematic = true;
            initialChairPositionZ = transform.localPosition.z;
        }

        private void OnCollisionEnter(Collision collision)
        {
            ControlCollision(collision);
        }

        private void ControlCollision(Collision collision)
        {
            if (!isChairMoving) return;

            if (ExtensionsMethods.IsInLayerMask(collision.gameObject.layer , chairSettings.successLayers))
            {
                sequenceController.OnChairMoveSuccess();
            }
            else if (ExtensionsMethods.IsInLayerMask(collision.gameObject.layer , chairSettings.failLayers))
            {
                sequenceController.OnChairMoveFail(collision.gameObject);
            }
        }
        
        public void StartMoveSequence()
        {
            if (!canMove) return;

            canMove = false;
            rb.isKinematic = false;
            isChairMoving = true;
            moveTween = transform.DOLocalMoveZ(chairSettings.selectMoveAmount, chairSettings.selectMoveDuration);
        }
        
        public void ResetMoveSequence()
        {
            isChairMoving = false;
            moveTween?.Kill();
            rb.isKinematic = true;
        }

        public void ResetPosition()
        {
            transform.DOLocalMoveZ(initialChairPositionZ, chairSettings.failMoveDuration).OnComplete(() =>
            {
                canMove = true;
            });
        }

        public void OnFailSequence()
        {
           
        }

        public void OnSuccessSequence()
        {
            
        }
    }
}