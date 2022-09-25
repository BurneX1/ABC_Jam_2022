using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValue : MonoBehaviour
{
    public EnergyType energyType;
    public UnityEngine.UI.Text text;
    public void GetText(UnityEngine.UI.Text text)
    {
        text.text = EnergyManager.GetValue(energyType).ToString();
    }
}