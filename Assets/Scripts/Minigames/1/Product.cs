using UnityEngine;

public class Product : MonoBehaviour
{
    public float price;
    public ProductType productType;
}

public enum ProductType
{
    Food, Tech, Home
}