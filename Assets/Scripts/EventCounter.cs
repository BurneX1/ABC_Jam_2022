using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class EventCounter : MonoBehaviour
{
    public UnityEvent winEvent;
    public UnityEvent dieEvent;
    public Text mesageCounter;
    public int messages = 3;
    public string[] dates;
    public UnityEngine.UI.Text currentDate;

    public void AddEventCount()
    {
        SaveSystem.data.eventCounter++;
        SaveSystem.Save();
    }

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
        if(SaveSystem.data.eventCounter >= 0 && SaveSystem.data.eventCounter < 3)
        {
            currentDate.text = dates[0];
        }
        else if(SaveSystem.data.eventCounter >= 3 && SaveSystem.data.eventCounter < 6)
        {
            currentDate.text = dates[1];
        }
        else if (SaveSystem.data.eventCounter >= 6 && SaveSystem.data.eventCounter < 9)
        {
            currentDate.text = dates[2];
        }
        else if (SaveSystem.data.eventCounter >= 9 && SaveSystem.data.eventCounter <= 12)
        {
            currentDate.text = dates[3];
        }
        else if(SaveSystem.data.eventCounter >= 12)
        {
            if(EnergyManager.GetValue(EnergyType.Economia) <= 0)
            {
                dieEvent.Invoke();
            }
            else
            {
                winEvent.Invoke();
            }

        }
    }

    void MessageCount()
    {
        messages--;
        if(messages <= 0)
        {
            messages = 3;
            GameObject.Find("FadePanel").GetComponent<ChangeScene>().Change("04_Minigame");
        }
        mesageCounter.text = "Tienes " + messages + " mensajes nuevos !!";

        

    }

}

