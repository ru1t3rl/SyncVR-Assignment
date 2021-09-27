using UnityEngine;
using DG.Tweening;

namespace Ru1t3rl.Effects
{
    public class SlideEffect : MonoBehaviour
    {
        [SerializeField] float animationTime;
        [SerializeField] Vector3 destination;

        public void Play()
        {
            transform.DOMove(destination, animationTime)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}