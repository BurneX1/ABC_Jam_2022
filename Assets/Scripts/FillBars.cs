using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class FillBars : MonoBehaviour
{
    public UnityEvent dieEvent;
    public EnergyType type;
    public Image img;
    public float uiReactSpd = 1;
    private int maxVal;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= EnergyManager.energies.Length;i++)
        {
            if(EnergyManager.energies[i].stat == type)
            {
                maxVal = EnergyManager.energies[i].maxValue;
                return;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        BarRefresh(img, EnergyManager.GetValue(type), maxVal);
        if(EnergyManager.GetValue(type) == 0 )
        {
            dieEvent.Invoke();
        }
    }
    private void BarRefresh(Image box, float act, float max)
    {
        if (box.fillAmount != act / max)
        {
            box.fillAmount = Mathf.Lerp(box.fillAmount, act / max, Time.deltaTime * uiReactSpd);
        }
    }
}
