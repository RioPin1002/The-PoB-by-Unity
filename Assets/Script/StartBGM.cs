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
        if (audioSource == null)
        {
            Debug.Log("???");
        }
        if (GameManager.gameStart == true)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
}
