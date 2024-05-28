using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeDestroyerandAddScore : MonoBehaviour
{
    public TextMeshProUGUI TimerText;  // TimerText はインスペクターで設定する
    public AudioClip sound1;           // sound1 はインスペクターで設定する
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource コンポーネントが存在することを確認
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on this GameObject.");
        }
        // sound1 が設定されていることを確認
        if (sound1 == null)
        {
            Debug.LogError("AudioClip (sound1) is not set in the inspector.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // TimerText が設定されていることを確認
        if (TimerText == null)
        {
            Debug.LogError("TextMeshProUGUI (TimerText) is not set in the inspector.");
            return;
        }

        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTagR"))
        {
            UpdateScore(50, 0);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("NodeTagL"))
        {
            UpdateScore(50, 3);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("NodeTagU"))
        {
            UpdateScore(50, 1);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("NodeTagD"))
        {
            UpdateScore(50, 2);
            Destroy(other.gameObject);
        }
    }

    private void UpdateScore(int scoreIncrement, int detectIndex)
    {
        GameManager.gameScore += scoreIncrement;
        GameManager.detectTime = Time.time;
        GameManager.detect[detectIndex] = 1;
        GameManager.triggerSound = 1;
        
        TimerText.text = "Score: " + GameManager.gameScore.ToString();

        if (audioSource != null && sound1 != null)
        {
            audioSource.PlayOneShot(sound1);
        }
    }
}
