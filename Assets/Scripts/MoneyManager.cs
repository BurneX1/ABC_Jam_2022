using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
    }
    public int money { get; private set; }

    public void AddMoney(int value)
    {
        money += value;
        EnergyManager.ModifyValues(value, EnergyType.Economia);
        HistoryEvents.RegisterNewEvent("Trabajo de medio tiempo", value, EnergyType.Economia);
    }
    public void SubstractMoney(int value)
    {
        money -= value;
        EnergyManager.ModifyValues(value*-1, EnergyType.Economia);
        HistoryEvents.RegisterNewEvent("Recortes salariales por errores laborales", value, EnergyType.Economia);
    }
}