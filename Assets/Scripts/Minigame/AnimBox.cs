using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimBox : MonoBehaviour
{
    private bool animate;

    private void Update()
    {
        if(animate)
        {
            animate = false;
            StartCoroutine(GetComponent<MiniScaleTweening>().TweenScale());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Product>() != null) animate = true;
    }
}