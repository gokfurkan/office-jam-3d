using System;
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
            if (Input.GetMouseButtonDown(0))
            {
                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, selectableLayer))
                {
                    Debug.Log("Selected Object: " + hit.transform.gameObject.name);
                }
            }
        }
    }
}