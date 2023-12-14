using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CounterFromGameStart : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    // Update is called once per frame
    void Update()
    {
        TimerText.text = (Time.time).ToString();
    }
}
