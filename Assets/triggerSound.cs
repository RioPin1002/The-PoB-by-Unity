using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSound : MonoBehaviour
{
    public AudioClip sound1;           // sound1 はインスペクターで設定する
    private AudioSource audioSource;


    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (GameManager.triggerSound == 1){
            audioSource.Play();
            GameManager.triggerSound = 0;
        }
    }
}
