using UnityEngine;
using TMPro;

public class TextDisplayScript : MonoBehaviour
{
    public TextMeshProUGUI displayText; // Unityインスペクタで表示するテキストオブジェクトをアタッチしてください


    
    
    // このメソッドは毎フレーム呼び出されます
    void Update()
    {
        Debug.Log(GameManager.detect);
        // あなたの条件に基づいてisConditionTrueを設定します
        // この例では、GameManager.detectがTrueの場合にisConditionTrueをTrueに設定しています
        bool isConditionTrue = GameManager.detect;

        // 条件がTrueの場合、テキストオブジェクトをアクティブに。Falseの場合、非アクティブにする
        displayText.gameObject.SetActive(isConditionTrue);
        if (Time.time - GameManager.detectTime > 0.2f)
        {
            GameManager.detect = false;
        }

        
    }
}
