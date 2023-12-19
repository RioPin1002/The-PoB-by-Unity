using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeDestroyerandAddScoreEX : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private void OnTriggerEnter(Collider other)
    {
        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTagEX"))
        {
            Debug.Log("HitEX");
            GameManager.gameScore += 50;
            TimerText.text = "Score: " + (GameManager.gameScore).ToString();


            // ノードを破棄
            Destroy(other.gameObject);
        }
    }
}
