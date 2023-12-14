using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeDestroyerandAddScore : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private void OnTriggerEnter(Collider other)
    {
        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTag"))
        {
            GameManager.gameScore += 50;
            TimerText.text = "Score: " + (GameManager.gameScore).ToString();


            // ノードを破棄
            Destroy(other.gameObject);
        }
    }
}
