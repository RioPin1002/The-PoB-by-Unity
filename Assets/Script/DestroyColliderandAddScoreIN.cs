using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeDestroyerandAddScoreIN : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private void OnTriggerEnterIN(Collider other)
    {
        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTagIN"))
        {
            Debug.Log("HitIn");
            GameManager.gameScore += 50;
            TimerText.text = "Score: " + (GameManager.gameScore).ToString();


            // ノードを破棄
            Destroy(other.gameObject);
        }
    }
}
