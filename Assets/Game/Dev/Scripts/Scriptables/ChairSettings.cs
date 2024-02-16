using UnityEngine;

namespace Game.Dev.Scripts.Scriptables
{
    [CreateAssetMenu(fileName = "ChairSettings", menuName = "ScriptableObjects/ChairSettings", order = 0)]
    public class ChairSettings : ScriptableObject
    {
        public LayerMask successLayers;
        public LayerMask failLayers;
        public float selectMoveAmount = 20;
        public float selectMoveDuration = 1.5f;
        public float failMoveDuration;
    }
}