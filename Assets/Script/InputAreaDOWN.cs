using System.Collections;
using UnityEngine;

public class InputAreaDOWN : MonoBehaviour
{
    public GameObject objectToActivate; // アクティブにするゲームオブジェクト
    public GameObject objectToActivate2; // アクティブにするゲームオブジェクト
    public KeyCode activationKey = KeyCode.Space; // アクティベートするためのキー
    public float activationDuration = 0.2f; // アクティブにする時間

    void Start()
    {
        // 初期状態では非アクティブに設定
        objectToActivate.SetActive(false);
        objectToActivate2.SetActive(false);
    }

    void Update()
    {
        // キーが押されたかどうかを確認
        if (CatchInputDataByPython.detect[0] == 1 || UDP.datacopy == 1)
        {
            // アクティブにして、一定時間後に非アクティブに戻す
            StartCoroutine(ActivateAndDeactivate());
            UDP.datacopy = 0;
        }
    }

    IEnumerator ActivateAndDeactivate()
    {
        // ゲームオブジェクトをアクティブにする
        objectToActivate.SetActive(true);
        objectToActivate2.SetActive(true);

        // 一定時間待機
        yield return new WaitForSeconds(activationDuration);

        // ゲームオブジェクトを非アクティブにする
        objectToActivate.SetActive(false);
        objectToActivate2.SetActive(false);
    }
}









/*
using System.Collections;
using UnityEngine;

public class InputArea : MonoBehaviour
{
    public GameObject objectToActivate; // アクティブにするゲームオブジェクト
    public KeyCode activationKey = KeyCode.Space; // アクティベートするためのキー
    public float activationDuration = 0.1f; // アクティブにする時間

    private bool keyLog = false;
    private float counter = 0; 

    void Start()
    {
        // 初期状態では非アクティブに設定
        objectToActivate.SetActive(false);
    }

    void Update()
    {
        // キーが押されたかどうかを確認
        if (Input.GetKeyDown(activationKey))
        {
            // アクティブにして、一定時間後に非アクティブに戻す
            objectToActivate.SetActive(true);
            keyLog = true;
        }

        if (keyLog == true)
        {
            counter += Time.deltaTime;
            if (counter > activationDuration)
            {
                objectToActivate.SetActive(false);
                keyLog = false;
            }
        }
    }
}
*/