using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Conclussion 
{
    public EnergyType modifierType;
    public int value;

    public void Conclude()
    {
        EnergyManager.ModifyValues(value, modifierType);
        HistoryEvents.RegisterNewEvent(modifierType.ToString(), value);
    }
}