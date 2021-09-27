using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hint : MonoBehaviour
{
    [SerializeField] float animationTime, timeVisible, coolDownTime;

    bool active = false;

    public void Show()
    {
        if (!active)
        {
            transform.DOScaleY(1, animationTime)
                .OnStart(() => active = true)
                .OnComplete(() => StartCoroutine(HintVisible()));
        }
    }

    IEnumerator HintVisible()
    {
        yield return new WaitForSeconds(timeVisible);
        Hide();
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(coolDownTime);
        active = false;
    }

    public void Hide()
    {
        transform.DOScaleY(0, animationTime).OnComplete(() => StartCoroutine(CoolDown()));
    }
}
