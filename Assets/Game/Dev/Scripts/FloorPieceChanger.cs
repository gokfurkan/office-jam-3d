using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Dev.Scripts
{
    public class FloorPieceChanger : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private List<Material> floorMaterials;
        
        private int currentMaterialIndex = 0;
        
        [Button]
        public void ChangeMaterial()
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % floorMaterials.Count;
            meshRenderer.material = floorMaterials[currentMaterialIndex];
        }
    }
}