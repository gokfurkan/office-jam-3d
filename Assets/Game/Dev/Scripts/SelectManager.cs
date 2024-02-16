using System;
using Template.Scripts;
using UnityEngine;

namespace Game.Dev.Scripts
{
    public class SelectManager : MonoBehaviour
    {
        public LayerMask selectableLayer;

        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            ControlSelect();
        }

        private void ControlSelect()
        {
            if (GameManager.instance.gameStatus.hasLevelEnd) return;
            
            if (Input.GetMouseButtonDown(0))
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, selectableLayer))
                {
                    BusSystem.CallSelectChair(hit.collider.gameObject);
                }
            }
        }
    }
}