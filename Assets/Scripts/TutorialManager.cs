using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject cuyIntro;
    public GameObject cuyMagico;
    public GameObject moneyCircle;
    //public static bool firstCuyIntro;
    public GameObject cuyTips;
    public GameObject toolTip;
    public GameObject blockPanel;
    public float tipDuration;
    private bool canReproduce = true;

    private void Start()
    {
        if(SaveSystem.data.alreadyPlayed)
        {
            cuyMagico.SetActive(true);
            moneyCircle.SetActive(true);
            toolTip.SetActive(false);
            cuyTips.SetActive(false);
            cuyIntro.SetActive(false);
        }
    }

    private IEnumerator cuyTip()
    {
        yield return new WaitUntil(() => cuyIntro.transform.parent.gameObject.activeInHierarchy == false);
        yield return new WaitForSeconds(0);
        GameObject.Find("Canvas").GetComponent<TweenScreens>().TweenPopUp(cuyTips.transform);
        AudioManager.Instance.Play("SegundoCuy");
        GameObject.Find("Canvas").GetComponent<TweenScreens>().TweenPopUp(toolTip.transform);
        blockPanel.SetActive(true);
        //firstCuyIntro = false;

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
                AudioManager.Instance.Play("PrimerCuy");
            }
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    cuyIntro.SetActive(false);
                    AudioManager.Instance.Stop("PrimerCuy");
                    //firstCuyIntro = true;
                    StartCoroutine(cuyTip());
                    SaveSystem.data.alreadyPlayed = true;
                    SaveSystem.Save();
                }
            }
            else if(Input.GetMouseButton(0))
            {
                cuyIntro.SetActive(false);
                AudioManager.Instance.Stop("PrimerCuy");
                //firstCuyIntro = true;
                StartCoroutine(cuyTip());
                SaveSystem.data.alreadyPlayed = true;
                SaveSystem.Save();
            }
        }
    }
}