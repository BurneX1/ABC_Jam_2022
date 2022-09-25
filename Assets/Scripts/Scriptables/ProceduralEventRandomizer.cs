using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralEventRandomizer : MonoBehaviour
{
    public static bool isFirstTime = true;
    public Events firstEvent;
    public Events[] mainEvents;
    public DecisionsAutofill decisionFill;


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

}
