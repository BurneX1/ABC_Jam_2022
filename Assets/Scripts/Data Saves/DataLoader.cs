using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    private void Awake()
    {
        SaveSystem.Load();

        if (SaveSystem.data.stats == null)
        {
            SaveSystem.data.stats = new int[5];
            for (int i = 0; i < SaveSystem.data.stats.Length; i++)
            {
                if (i != 2)
                {
                    SaveSystem.data.stats[i] = 200;
                    SaveSystem.Save();
                }
                else
                {
                    SaveSystem.data.stats[i] = 700;
                    SaveSystem.Save();
                }
            }
        } 
    }
}