using UnityEngine;
using TMPro;

public class TextDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI displayTextP; // Unityインスペクタで表示するテキストオブジェクトをアタッチしてください
    public TextMeshProUGUI displayTextB; // Unityインスペクタで表示するテキストオブジェクトをアタッチしてください
    public TextMeshProUGUI displayTextR; // Unityインスペクタで表示するテキストオブジェクトをアタッチしてください
    public TextMeshProUGUI displayTextY; // Unityインスペクタで表示するテキストオブジェクトをアタッチしてください

    public AudioClip sound1;
    AudioSource audioSource;

    private bool[] detectData = new bool[] { false, false, false, false };
  
    
    
    // このメソッドは毎フレーム呼び出されます
    void Update()
    {
        // あなたの条件に基づいてisConditionTrueを設定します
        // この例では、GameManager.detectがTrueの場合にisConditionTrueをTrueに設定しています
        //p = 0 b = 1 r = 2 y = 3

        for (int i = 0; i < detectData.Length; i++){
            if (GameManager.detect[i] == 1){
                
                detectData[i] = false;
            }
        }

        if (GameManager.detect[0] == 1){
            
            displayTextP.gameObject.SetActive(true);
            
            if (Time.time - GameManager.detectTime > 0.2f)
            {
                
                GameManager.detect[0] = 0;
                detectData[0] = false;
                

            }
        } else {
            displayTextP.gameObject.SetActive(false);
        }
        if (GameManager.detect[1] == 1){
            displayTextB.gameObject.SetActive(true);
            
            if (Time.time - GameManager.detectTime > 0.2f)
            {
                GameManager.detect[1] = 0;
                detectData[1] = false;
                
            }
        } else {
            displayTextB.gameObject.SetActive(false);
        }
        if (GameManager.detect[2] == 1){
            displayTextR.gameObject.SetActive(true);
            
            if (Time.time - GameManager.detectTime > 0.2f)
            {
                GameManager.detect[2] = 0;
                detectData[2] = false;
                
            }
        } else {
            displayTextR.gameObject.SetActive(false);
        }
        if (GameManager.detect[3] == 1){
            displayTextY.gameObject.SetActive(true);
            
            if (Time.time - GameManager.detectTime > 0.2f)
            {
                GameManager.detect[3] = 0;
                detectData[3] = false;
                
            }
        } else {
            displayTextY.gameObject.SetActive(false);
        }

        // 条件がTrueの場合、テキストオブジェクトをアクティブに。Falseの場合、非アクティブにする

        
    }
}
