using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartCountdown : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI countdownText;
    private int countdownNum = 4;


    private void Start() {
        InvokeRepeating("decreaseCountdown", 0f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.countdown == true)
        {
            if (countdownNum > 0)
            {
                countdownText.text = (countdownNum).ToString();
            }else{
                countdownText.text = "スタート";
                destroyCountdownText();
            }
        }
    }

    void decreaseCountdown()
    {
        countdownNum--;
    }

    void destroyCountdownText()
    {
        Destroy(countdownText, 1f);
        Color textColor = countdownText.color;
        
        if (countdownText.color.a < 1)
        {
            textColor.a -= GameManager.fadeoutSpeed;
        }
        countdownText.color = textColor;
        GameManager.gameStart = true;
    }


}
