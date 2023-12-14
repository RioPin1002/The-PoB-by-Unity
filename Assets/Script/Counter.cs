using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    public static float timeFromStart = 0f;

    public TextMeshProUGUI TimerText;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameContinuing == true)
        {
            timeFromStart += Time.deltaTime;
        }   TimerText.text = "音楽開始: " + (Math.Floor(timeFromStart/60)).ToString() + ":" + (timeFromStart%60).ToString("f2");
    }
}
