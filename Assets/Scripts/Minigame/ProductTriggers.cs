using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductTriggers : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Product boxType = collision.gameObject.GetComponent<Product>();
        Product thisProductType = gameObject.GetComponent<Product>();

        if (collision.CompareTag("Boxes") && 
            boxType.productType == thisProductType.productType &&
            GetComponent<DragAndDrop>().drag)
        {
            MoneyManager.Instance.AddMoney(thisProductType.price);
            Debug.Log(MoneyManager.Instance.money);
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Boxes") &&
            boxType.productType != thisProductType.productType &&
            GetComponent<DragAndDrop>().drag)
        {
            MoneyManager.Instance.SubstractMoney(thisProductType.price);
            Debug.Log(MoneyManager.Instance.money);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cinta") && !GetComponent<DragAndDrop>().drag) Destroy(gameObject);
    }
}