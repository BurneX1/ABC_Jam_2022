using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class HistoryEvents : MonoBehaviour
{

    public static string[] excecutetEvents = new string[0];
    public static string[] valueEvents = new string[0];
    public static EnergyType[] eventType = new EnergyType[0];


    public static HistoryEvents Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public static void RegisterNewEvent(string even, int value, EnergyType stat)
    {
        string[] concatEvent = new string[] { stat.ToString() }; //Modificado por convenienvia(deberia de ir el even)
        string[] concatValue = new string[] { value.ToString() };
        EnergyType[] concatType = new EnergyType[] { stat };

        if (excecutetEvents.Length == 0 || valueEvents.Length == 0)
        {
            excecutetEvents = concatEvent;
            valueEvents = concatValue;
            eventType = concatType;
        }
        else
        {
            excecutetEvents = excecutetEvents.Concat(concatEvent).ToArray();
            valueEvents = valueEvents.Concat(concatValue).ToArray();
            eventType = eventType.Concat(concatType).ToArray();

        }

        /*for (int i = 0; i < excecutetEvents.Length; i++)
        {
            Debug.Log("Array: " + i + excecutetEvents[i]);
        }
        for (int e = 0; e < valueEvents.Length; e++)
        {
            Debug.Log("Array: " + e + valueEvents[e]);

        }
        for (int u = 0; u < valueEvents.Length; u++)
        {
            Debug.Log("Array: " + u + valueEvents[u]);

        }*/
    }
}

