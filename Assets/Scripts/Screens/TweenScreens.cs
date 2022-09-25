using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenScreens : MonoBehaviour
{
    public float duration;

    public void TweenPopUp(Transform popUp)
    {
        popUp.localScale = Vector3.zero;
        popUp.gameObject.SetActive(true);
        popUp.DOScale(1, duration).SetEase(Ease.OutBack);
    }

    public void HidePopUp(Transform popUp) => StartCoroutine(hidePop(popUp));

    private IEnumerator hidePop(Transform popUp)
    {
        popUp.DOScale(0, duration).SetEase(Ease.InBack);
        yield return new WaitUntil(() => popUp.localScale == Vector3.zero);
        popUp.gameObject.SetActive(false);
    }
}