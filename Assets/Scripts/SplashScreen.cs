using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    void Update()
    {
        if(Input.touchCount > 0)
            FindObjectOfType<ChangeScene>().Change("02_MainMenu");
    }
}