using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductTriggers : MonoBehaviour
{
    public bool ableToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Product boxType = collision.gameObject.GetComponent<Product>();
        Product thisProductType = gameObject.GetComponent<Product>();

        if (collision.CompareTag("Boxes") && GetComponent<DragAndDrop>().drag)
        {
            if (boxType.productType == thisProductType.productType)
            {
                MoneyManager.Instance.AddMoney(thisProductType.price);
                Debug.Log(MoneyManager.Instance.money);
                Destroy(gameObject);
            }
            else
            {
                MoneyManager.Instance.SubstractMoney(thisProductType.price);
                Debug.Log(MoneyManager.Instance.money);
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Cinta")) ableToDestroy = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cinta")) ableToDestroy = true;
    }
}