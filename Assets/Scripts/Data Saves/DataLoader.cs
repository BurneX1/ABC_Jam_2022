using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private void Awake() => SaveSystem.Load();

    private void Start()
    {
        if (SaveSystem.data.stats == null)
        {
            SaveSystem.data.stats = new int[5];
            for (int i = 0; i < SaveSystem.data.stats.Length; i++)
            {
                SaveSystem.data.stats = new int[5];
                if (i != 2) SaveSystem.data.stats[i] = 200;
                else SaveSystem.data.stats[i] = 1000;
            }
        }        
    }
}