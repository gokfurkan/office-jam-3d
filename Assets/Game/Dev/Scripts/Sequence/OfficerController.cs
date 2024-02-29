using System.Collections;
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
        [SerializeField] private Material failMaterial;

        [Space(10)] 
        [SerializeField] private ParticleSystem sleepParticle;
      
        
        private static readonly int Typing = Animator.StringToHash("Typing");

        public void InitOfficer()
        {
            meshRenderer.material = passiveMaterial;
            sleepParticle.Play();
        }
        
        public void OnSuccessSequence()
        {
            meshRenderer.material = activeMaterial;
            
            sleepParticle.Stop();
            animator.SetTrigger(Typing);
        }

        public void OnFailSequence()
        {
            StartCoroutine(ChangeToFailMaterialSequence());
        }

        private IEnumerator ChangeToFailMaterialSequence()
        {
            meshRenderer.material = failMaterial;
            yield return new WaitForSeconds(0.35f);
            meshRenderer.material = passiveMaterial;
        }
    }
}