using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class ProceduralEventRandomizer : MonoBehaviour
{
    public static bool isFirstTime = true;
    public Events firstEvent;
    public Events[] mainEvents;
    public DecisionsAutofill decisionFill;
    public Events[] eventList;

    private void Start()
    {
        RefreshList();
    }
    public void SetNewEvent()
    {
        if (isFirstTime == true)
        {
            decisionFill.actualEvent = firstEvent;
            isFirstTime = false;
        }
        else
        {
            decisionFill.actualEvent = mainEvents[Random.Range(0, mainEvents.Length)];
        }

        decisionFill.RefreshEvent();
    }

    public void RefreshList()
    {
        Events[] NullEv = { };
        eventList = NullEv;
        for(int i = 0;i<mainEvents.Length;i++)
        {
            VerifyEvent(mainEvents[i]);
        }
    }


    public void VerifyEvent(Events ev)
    {
        Events[] addEv = { ev };
        switch (ev.condition)
        {
            case ValueCondition.Unconditioned:

                AddEvent(ev);
                break;

            case ValueCondition.Greater:
                if (EnergyManager.GetPorcent(ev.dependenceType) >= ev.valuePorcent)
                {
                    AddEvent(ev);
                    Debug.LogError(ev.dependenceType + " " + EnergyManager.GetPorcent(ev.dependenceType) + " >= " + ev.valuePorcent);
                }
                break;

            case ValueCondition.Lesser:
                if (EnergyManager.GetPorcent(ev.dependenceType) <= ev.valuePorcent)
                {
                    Debug.LogError(ev.dependenceType + " " + EnergyManager.GetPorcent(ev.dependenceType) + " <= " + ev.valuePorcent);
                    AddEvent(ev);
                }
                break;
        }
    }
    public void AddEvent(Events ev)
    {
        Events[] addEv = { ev };
        if (eventList.Length == 0)
        {
            eventList = addEv;
        }
        else
        {
            eventList = eventList.Concat(addEv).ToArray();
        }
    }
}
