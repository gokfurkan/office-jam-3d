using UnityEngine;

namespace Game.Dev.Scripts.Sequence
{
    public class OfficerController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        
        [Space(10)]
        [SerializeField] private SkinnedMeshRenderer meshRenderer;
        [SerializeField] private Material activeMaterial;
        [SerializeField] private Material passiveMaterial;
      
        
        private static readonly int Typing = Animator.StringToHash("Typing");

        public void InitOfficer()
        {
            meshRenderer.material = passiveMaterial;
        }
        
        public void OnSuccessSequence()
        {
            meshRenderer.material = activeMaterial;
            
            animator.SetTrigger(Typing);
        }
    }
}