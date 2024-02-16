﻿using System;
using DG.Tweening;
using Game.Dev.Scripts.Scriptables;
using Template.Scripts;
using UnityEngine;

namespace Game.Dev.Scripts
{
    public class ChairController : MonoBehaviour
    {
        [SerializeField] private ChairSettings chairSettings;
        [SerializeField] private OfficerDeskSequence officerDeskSequence;
        [SerializeField] private Rigidbody rb;

        private bool canMove;
        private bool isChairMoving;
        private Tween moveTween;
        private float initialChairPositionZ;
        
        private void Start()
        {
            canMove = true;
            rb.isKinematic = true;
            initialChairPositionZ = transform.localPosition.z;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!isChairMoving) return;

            if (ExtensionsMethods.IsInLayerMask(collision.gameObject.layer , chairSettings.successLayers))
            {
                officerDeskSequence.OnChairMoveSuccess();
            }
            else if (ExtensionsMethods.IsInLayerMask(collision.gameObject.layer , chairSettings.failLayers))
            {
                officerDeskSequence.OnChairMoveFail();

                var collChairController = collision.gameObject.GetComponent<ChairController>();
                if (collChairController != null)
                {
                    collChairController.HandleCollisionWithAnotherChair();
                }
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
            transform.DOLocalMoveZ(initialChairPositionZ, chairSettings.selectMoveDuration).OnComplete(() =>
            {
                canMove = true;
            });
        }

        public void HandleCollisionWithAnotherChair()
        {
            Debug.Log("Hit another chair");
        }

        public void OnOfficerSitDesk()
        {
            Debug.Log("On chair success sequence");
        }
    }
}