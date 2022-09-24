using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New event", menuName = "Events")]
public class Events : ScriptableObject
{
    public string eventName;
    public string eventDescription;
    public Conclussion affirmativeConclu;
    public Conclussion negativeConclu;
}