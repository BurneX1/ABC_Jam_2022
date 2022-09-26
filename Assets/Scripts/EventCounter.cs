using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventCounter : MonoBehaviour
{
    public int counter;
    public Text mesageCounter;
    public int messages = 3;
    public string[] dates;
    public UnityEngine.UI.Text currentDate;

    public void AddEventCount() => counter++;

    private void OnEnable()
    {
        mesageCounter.text = "Tienes " + messages + " mensajes nuevos !!";
        ConclsGroup.NewEventSucces += AddEventCount;
        ConclsGroup.NewEventSucces += MessageCount;
    }
    private void OnDisable()
    {
        ConclsGroup.NewEventSucces -= AddEventCount;
        ConclsGroup.NewEventSucces -= MessageCount;
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

    void MessageCount()
    {
        messages--;
        if(messages <= 0)
        {
            messages = 3;
            GameObject.Find("FadePanel").GetComponent<ChangeScene>().Change("03_Minigame");
        }
        mesageCounter.text = "Tienes " + messages + " mensajes nuevos !!";

        

    }

}

