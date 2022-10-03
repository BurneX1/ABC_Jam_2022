using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject onBoarding;

    private void Start()
    {
        if (SaveSystem.data.firstTime) onBoarding.SetActive(true);
        else onBoarding.SetActive(false);
    }

    public void SetFirstTime() { SaveSystem.data.firstTime = false; SaveSystem.Save(); }
}