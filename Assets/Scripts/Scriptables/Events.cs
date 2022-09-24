using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New event", menuName = "Events")]
public class Events : ScriptableObject
{
    public string eventName;
    [TextArea]
    public string eventDescription;

    [Space]
    [Header("Afirmative")]
    public ConclsGroup affirmativeConclussion;
    [Space]
    [Header("Negative")]
    public ConclsGroup negativeConclussion;

    public void ExcecuteConclussion(ConclsGroup efectsList)
    {
        efectsList.ResolveConclussions();
    }
}