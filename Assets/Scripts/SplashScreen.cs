using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    private void Start()
    {
        SaveSystem.Load();
        StartCoroutine(splash());
    }
    private IEnumerator splash()
    {
        yield return new WaitForSeconds(1.5f);
        if(SaveSystem.data.firstTime == false) FindObjectOfType<ChangeScene>().Change("03_MainMenu");
        else FindObjectOfType<ChangeScene>().Change("02_History");
    }
}