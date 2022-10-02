using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTime : MonoBehaviour
{
    public float minigameTime = 80;
    public UnityEngine.UI.Text text;

    private void Update()
    {
        minigameTime -= Time.deltaTime;
        text.text = minigameTime.ToString("00");
        if (minigameTime <= 0) FindObjectOfType<ChangeScene>().Change("03_MainMenu");
    }
}