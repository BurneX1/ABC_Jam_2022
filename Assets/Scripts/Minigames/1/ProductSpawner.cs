using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawner : MonoBehaviour
{
    public GameObject[] productPrefabs;
    public float minSpawnRate, maxSpawnRate;
    private float timer;
    private float randomRate;

    private void Start() => randomRate = GetRandomRate();

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= randomRate)
        {
            if (productPrefabs == null || productPrefabs.Length == 0)
            {
                Debug.LogWarning("No asignaste prefabs de productos");
                return;
            }
            else Spawn(productPrefabs[GetRandomProduct()]);
            timer = 0;        
        }
    }

    private int GetRandomProduct()
    {
        return Random.Range(0, productPrefabs.Length);
    }
    private float GetRandomRate()
    {
        return Random.Range(minSpawnRate, maxSpawnRate);
    }

    private void Spawn(GameObject productPrefab)
    {
        GameObject obj = Instantiate(productPrefab);
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
        randomRate = GetRandomRate();
    }
}