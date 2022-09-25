using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ConclsGroup
{
    public string text;
    public Conclussion[] conclussion;

    public void ResolveConclussions()
    {
        if (conclussion.Length <= 0) return;

        for(int i = 0; i < conclussion.Length;i++)
        {
            conclussion[i].Conclude();
        }
    }
}
