using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LogKeyPress : MonoBehaviour
{
    private float startTime;
    private List<string> logData = new List<string>();
    private string csvFilePath = "keyPressLog.csv";

    void Start()
    {
        // ゲーム開始時の時間を取得
        startTime = Time.time;

        // CSVファイルのヘッダを書き込む
        WriteToCSV("Time,SKeyPressed,KKeyPressed");
    }

    void Update()
    {
        // キー入力があるか確認
        if (Input.anyKeyDown)
        {
            // 現在の経過時間を取得
            float elapsedTime = Time.time - startTime;

            // sキーとkキーの入力状況を取得
            string sKeyPressed = Input.GetKeyDown(KeyCode.S) ? "1" : "0";
            string kKeyPressed = Input.GetKeyDown(KeyCode.K) ? "1" : "0";

            // ログに追加
            logData.Add($"{elapsedTime},{sKeyPressed},{kKeyPressed}");

            // CSVファイルに書き込む
            WriteToCSV($"{elapsedTime},{sKeyPressed},{kKeyPressed}");
        }
    }

    void WriteToCSV(string data)
    {
        // CSVファイルにデータを書き込む
        using (StreamWriter sw = File.AppendText(csvFilePath))
        {
            sw.WriteLine(data);
        }
    }
}