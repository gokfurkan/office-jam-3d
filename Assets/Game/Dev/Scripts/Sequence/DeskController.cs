using DG.Tweening;
using UnityEngine;

namespace Game.Dev.Scripts.Sequence
{
    public class DeskController : MonoBehaviour
    {
        [SerializeField] private GameObject pc;
        [SerializeField] private float punchAmount;
        [SerializeField] private float punchDuration;

        [Space(10)] 
        [SerializeField] private GameObject pcActive;
        [SerializeField] private ParticleSystem pcActivateParticle;
        
        public void InitDesk()
        {
            pcActive.SetActive(false);
        }
        
        public void OnSuccessSequence()
        {
            pc.transform.DOPunchScale(Vector3.one * punchAmount, punchDuration);
            
            pcActive.SetActive(true);
            pcActivateParticle.Play();
        }
    }
}