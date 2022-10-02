using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionsAutofill : MonoBehaviour
{
    public Events actualEvent;
    public GameObject efectUIpref;

    [Space]
    public Text title;
    public Text description;
    public Button afrBtn;
    public Text afrText;
    public GameObject afGrp;
    public Button ngtBtn;
    public Text ngtText;
    public GameObject ngtGrp;
    // Start is called before the first frame update
    void Start()
    {
        RefreshEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshEvent()
    {
        if(actualEvent ==null)
        {
            return;
        }

        title.text = actualEvent.eventName;
        description.text = actualEvent.eventDescription;
        afrText.text = actualEvent.affirmativeConclussion.text;
        ngtText.text = actualEvent.negativeConclussion.text;

        afrBtn.onClick.RemoveAllListeners();
        ngtBtn.onClick.RemoveAllListeners();

        afrBtn.onClick.AddListener(delegate { actualEvent.affirmativeConclussion.ResolveConclussions(); });
        ngtBtn.onClick.AddListener(delegate { actualEvent.negativeConclussion.ResolveConclussions(); });

        foreach (Transform child in afGrp.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in ngtGrp.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < actualEvent.affirmativeConclussion.conclussion.Length;i++)
        {

            GameObject obj = Instantiate(efectUIpref, afGrp.transform);
            obj.GetComponentInChildren<EfectElements>().txt.text = actualEvent.affirmativeConclussion.conclussion[i].value + "";
            Sprite spr = null;

            for (int e = 0; e < EnergyManager.energies.Length; e++)
            {
                if (EnergyManager.energies[e].stat == actualEvent.affirmativeConclussion.conclussion[i].modifierType)
                {
                    spr = EnergyManager.energies[e].icon;
                    break;
                }
            }
            obj.GetComponentInChildren<EfectElements>().icon.sprite = spr;
            obj.GetComponentInChildren<EfectElements>().icon.SetNativeSize();

        }

        for (int i = 0; i < actualEvent.negativeConclussion.conclussion.Length; i++)
        {

            GameObject obj = Instantiate(efectUIpref, ngtGrp.transform);
            obj.GetComponentInChildren<EfectElements>().txt.text = actualEvent.negativeConclussion.conclussion[i].value + "";
            Sprite spr = null;

            for(int e = 0; e<EnergyManager.energies.Length;e++)
            {
                if(EnergyManager.energies[e].stat == actualEvent.negativeConclussion.conclussion[i].modifierType)
                {
                    spr = EnergyManager.energies[e].icon;
                    break;
                }
            }
            obj.GetComponentInChildren<EfectElements>().icon.sprite = spr;
            obj.GetComponentInChildren<EfectElements>().icon.SetNativeSize();

        }
    }

    public void SetAfirmative(Button btn)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate { actualEvent.affirmativeConclussion.ResolveConclussions(); });
    }

    public void SetNegative(Button btn)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(delegate { actualEvent.negativeConclussion.ResolveConclussions(); });
    }
    public void SingleRefresh()
    {

    }
}
