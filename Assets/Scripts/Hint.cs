using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ru1t3rl
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] float animationTime, timeVisible, coolDownTime;
        [SerializeField] Image coolDownImage;
        public UnityEvent OnUseHint;

        bool active = false;

        public void Show()
        {
            if (!active)
            {
                coolDownImage.fillAmount = 1;

                transform.DOScaleY(1, animationTime)
                    .OnStart(() => active = true)
                    .OnComplete(() => StartCoroutine(HintVisible()));

                OnUseHint?.Invoke();
            }
        }

        IEnumerator HintVisible()
        {
            yield return new WaitForSeconds(timeVisible);
            Hide();
        }

        IEnumerator CoolDown()
        {
            DOTween.To(() => coolDownImage.fillAmount, x => coolDownImage.fillAmount = x, 0, coolDownTime);
            yield return new WaitForSeconds(coolDownTime);
            active = false;
        }

        public void Hide()
        {
            transform.DOScaleY(0, animationTime).OnComplete(() => StartCoroutine(CoolDown()));
        }
    }
}