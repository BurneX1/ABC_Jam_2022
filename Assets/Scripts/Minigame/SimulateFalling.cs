using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SimulateFalling : MonoBehaviour
{
    public float duration;
    public Vector3 endRotation;
    public string soundName;

    public IEnumerator Fall()
    {
        transform.parent = null;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        transform.DORotate(new Vector3(endRotation.x, endRotation.y, endRotation.z), duration, RotateMode.LocalAxisAdd);
        transform.DOScale(Vector3.zero, duration);
        //AudioManager.Instance.Play(soundName);
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}