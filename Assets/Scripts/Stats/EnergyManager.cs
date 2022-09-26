using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnergyManager : MonoBehaviour
{
    public static event Action ValuesRefreshed = delegate { };
    public EnergyStat[] energieArray;
    public static EnergyStat[] energies;

    public static EnergyManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        SetEnergie();
    }

    private void Update()
    {
        energieArray = energies;
    }
    //Funciones no estaticas recomendable trasladar a un script de UnityEditor
    public void SetEnergie()
    {
        energies = energieArray;
    }
    public static void ModifyValues(int amount, EnergyType type)
    {
        for(int i = 0; i < energies.Length;i++)
        {
            if(energies[i].stat == type)
            {
      
                energies[i].value += amount;

                if (energies[i].validateMaxValue == true)
                {
                    if (energies[i].value >=energies[i].maxValue)
                    {
                        energies[i].value = energies[i].maxValue;
                    }
                }

                ValuesRefreshed.Invoke();
            }
        }
    }
    
    public static int GetValue(EnergyType type)
    {
        for (int e = 0; e < energies.Length; e++)
        {
            if (energies[e].stat == type)
            {
                return energies[e].value;
            }
        }

        return 0;
    }
}
