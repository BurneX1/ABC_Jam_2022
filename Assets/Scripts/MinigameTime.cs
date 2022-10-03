using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameTime : MonoBehaviour
{
    public float minigameTime = 80;
    public UnityEngine.UI.Text text;
    public GameObject go;
    public TweenScreens ts;

    public UnityEvent onFinish;
    private bool able;

    private void Update()
    {
        minigameTime -= Time.deltaTime;
        text.text = minigameTime.ToString("00");
        if (minigameTime <= 0 && able == false)
        {
            if(MoneyManager.Instance.money >= 0) 
                go.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.
                    GetComponent<UnityEngine.UI.Text>().text = "+" + MoneyManager.Instance.money;
            else go.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.
                    GetComponent<UnityEngine.UI.Text>().text = "" + MoneyManager.Instance.money;

            able = true;
            minigameTime = 0;
            enabled = false;
            ts.TweenPopUp(go.transform);
            onFinish.Invoke();
        }
    }
}