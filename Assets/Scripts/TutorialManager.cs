using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject cuyIntro;
    public bool firstCuyIntro;
    private bool canReproduce = true;

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
                }
            }
            else if(Input.GetMouseButton(0))
            {
                cuyIntro.SetActive(false);
                AudioManager.Instance.Stop("Theme");
            }

        }
    }
}