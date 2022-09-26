using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HistUIAutofill : MonoBehaviour
{
    public GameObject textPrefab;

    public GameObject eventTextGroup;
    public GameObject valueTextGroup;

    public void Refresh()
    {
        Fill(eventTextGroup, HistoryEvents.excecutetEvents);
        Fill(valueTextGroup, HistoryEvents.valueEvents);
    }

    private void Fill(GameObject group, string[] thisArray)
    {
        foreach (Transform child in group.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < thisArray.Length; i++)
        {
            if(HistoryEvents.eventType[i] == EnergyType.Economia)
            {
                GameObject obj = Instantiate(textPrefab, group.transform);
                obj.GetComponentInChildren<Text>().text = thisArray[i];
            }
        }
    }
}
