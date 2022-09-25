using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValue : MonoBehaviour
{

    public EnergyType energyType;
    public UnityEngine.UI.Text text;

    private void Start()
    {
        EnergyManager.ValuesRefreshed += GetText;
    }
    public void GetText()
    {
        text.text = EnergyManager.GetValue(energyType).ToString();
    }
}