using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MiniScaleTweening : MonoBehaviour
{
    public float maxSize;
    public float duration;
    public IEnumerator TweenScale()
    {
        Vector3 initialScale = transform.localScale;
        transform.DOScale(maxSize, duration).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(duration);
        transform.DOScale(initialScale, duration).SetEase(Ease.OutBack);
    }
}