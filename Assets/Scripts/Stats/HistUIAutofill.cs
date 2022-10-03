using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HistUIAutofill : MonoBehaviour
{
    public EnergyStat[] stIc;
    public GameObject textPrefab;

    public GameObject eventTextGroup;

    private void Start()
    {
        Refresh();
    }
    public void Refresh()
    {
        Fill(eventTextGroup, HistoryEvents.excecutetEvents);
    }

    private void Fill(GameObject group, string[] thisArray)
    {
        foreach (Transform child in group.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < thisArray.Length; i++)
        {
            /*if(HistoryEvents.eventType[i] == EnergyType.Economia)
            {*/
                GameObject obj = Instantiate(textPrefab, group.transform);
                obj.GetComponentInChildren<HistUnit>().typeTxt.text = HistoryEvents.excecutetEvents[i];
                obj.GetComponentInChildren<HistUnit>().valueTxt.text = HistoryEvents.valueEvents[i];
                    //obj.GetComponentInChildren<HistUnit>().icon =
                obj.GetComponentInChildren<HistUnit>().eventTxt.text = HistoryEvents.excecutetEvents[i];

            for(int e = 0; e< stIc.Length;e++)
            {
                if(stIc[e].stat == HistoryEvents.eventType[i])
                {
                    Debug.Log(stIc[e].stat.ToString() + " " + HistoryEvents.excecutetEvents[i]);
                    obj.GetComponentInChildren<HistUnit>().icon.sprite = stIc[e].icon;
                    break;
                }
                Debug.Log("a");
            }
            //}
        }
    }
}
