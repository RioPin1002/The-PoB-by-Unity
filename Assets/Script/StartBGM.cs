using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBGM : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update() {
        if (GameManager.gameStart == true)
        {
            Debug.Log("音楽再生開始");
            audioSource.Play();
            GameManager.gameStart = false;
        }
    }
}
