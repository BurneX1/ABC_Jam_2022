using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool drag;
    private void OnMouseDown() => drag = true;
    private void OnMouseUp() => drag = false;

    private void Update()
    {
        if(drag)
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(MousePos);
        }

        if(GetComponent<ProductTriggers>().ableToDestroy && !drag)
        {
            GetComponent<ProductTriggers>().ableToDestroy = false;
            StartCoroutine(GetComponent<SimulateFalling>().Fall());
        }  
    }
}