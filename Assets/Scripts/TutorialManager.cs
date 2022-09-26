using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject cuyIntro;
    public bool firstCuyIntro;
    public GameObject cuyTips;
    public GameObject toolTip;
    public GameObject blockPanel;
    public float tipDuration;
    private bool canReproduce = true;

    private void Start()
    {
        StartCoroutine(cuyTip());
    }

    private IEnumerator cuyTip()
    {
        yield return new WaitUntil(() => firstCuyIntro);
        yield return new WaitUntil(() => cuyIntro.transform.parent.gameObject.activeInHierarchy == false);
        yield return new WaitForSeconds(1);
        GameObject.Find("Canvas").GetComponent<TweenScreens>().TweenPopUp(cuyTips.transform);
        AudioManager.Instance.Play("Theme");
        GameObject.Find("Canvas").GetComponent<TweenScreens>().TweenPopUp(toolTip.transform);
        blockPanel.SetActive(true);
        firstCuyIntro = false;

        yield return new WaitForSeconds(tipDuration);
        GameObject.Find("Canvas").GetComponent<TweenScreens>().HidePopUp(cuyTips.transform);
        GameObject.Find("Canvas").GetComponent<TweenScreens>().HidePopUp(toolTip.transform);
        blockPanel.SetActive(false);
    }

    private void Update()
    {
        if(cuyIntro.activeInHierarchy)
        {
            if(canReproduce)
            {
                canReproduce = false;
                AudioManager.Instance.Play("Theme");
            }
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    cuyIntro.SetActive(false);
                    AudioManager.Instance.Stop("Theme");
                    firstCuyIntro = true;
                }
            }
            else if(Input.GetMouseButton(0))
            {
                cuyIntro.SetActive(false);
                AudioManager.Instance.Stop("Theme");
                firstCuyIntro = true;
            }
        }
    }
}