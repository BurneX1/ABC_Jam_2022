using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCounter : MonoBehaviour
{
    public int counter;
    public string[] dates;
    public UnityEngine.UI.Text currentDate;

    public void AddEventCount() => counter++;

    private void Awake()
    {
        ConclsGroup.NewEventSucces += AddEventCount;
    }

    private void Update()
    {
        if(counter >= 0 && counter < 3)
        {
            currentDate.text = dates[0];
        }
        else if(counter >= 3 && counter < 6)
        {
            currentDate.text = dates[1];
        }
        else if (counter >= 6 && counter < 9)
        {
            currentDate.text = dates[2];
        }
        else if (counter >= 9 && counter <= 12)
        {
            currentDate.text = dates[3];
        }
    }
}