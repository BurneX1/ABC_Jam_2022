using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class ConclsGroup
{
    public static event Action NewEventSucces = delegate { };
    public string text;
    public Conclussion[] conclussion;

    public void ResolveConclussions()
    {
        if (conclussion.Length <= 0) return;

        for(int i = 0; i < conclussion.Length;i++)
        {
            conclussion[i].Conclude();
            HistoryEvents.RegisterNewEvent(text, conclussion[i].value, conclussion[i].modifierType);
            
        }
        NewEventSucces.Invoke();
    }
}
