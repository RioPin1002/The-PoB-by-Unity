using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool countdown = true;
    public static float fadeoutSpeed = 0.2f;

    public static int gameScore = 0;

    public static int[] detect = new int[] { 0, 0, 0, 0 };

    public static int triggerSound = 0;

    public static float detectTime;

    public static bool gameStart = false;
    public static bool gameContinuing = false;

    public void Update() {
        
    }
}
