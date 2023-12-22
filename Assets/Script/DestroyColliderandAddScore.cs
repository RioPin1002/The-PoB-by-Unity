using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeDestroyerandAddScore : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public AudioClip sound1;
    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {

        // ノードがColliderに触れた場合
        if (other.CompareTag("NodeTagEX") || other.CompareTag("NodeTagIN"))
        {
            GameManager.gameScore += 50;
            GameManager.detect = true;
            GameManager.detectTime = Time.time;
            
            TimerText.text = "Score: " + (GameManager.gameScore).ToString();
            audioSource.PlayOneShot(sound1);


            // ノードを破棄
            Destroy(other.gameObject);
        }
    }
}
