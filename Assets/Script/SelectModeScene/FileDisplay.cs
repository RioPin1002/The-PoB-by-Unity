using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileDisplay : MonoBehaviour
{
    public GameObject buttonPrefab;  // ボタンのプレハブ
    public Transform buttonContainer;  // ボタンを配置するコンテナ
    public TextMeshProUGUI selectedFileText;  // 選択されたファイル名を表示するTextMeshPro
    private string selectedFileName;  // 選択されたファイル名を格納する変数

    void Start()
    {
        DisplayFilesInDirectory();
    }

    void DisplayFilesInDirectory()
    {
        // ここで表示したいディレクトリを指定
        string directoryPath = "Assets/Resources";
        
        // 指定ディレクトリのファイルリストを取得
        string[] files = Directory.GetFiles(directoryPath);

        // ファイルごとにボタンを生成
        foreach (string file in files)
        {
            GameObject button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = Path.GetFileName(file);
            button.GetComponent<Button>().onClick.AddListener(() => OnFileButtonClick(Path.GetFileName(file)));
        }
    }

    void OnFileButtonClick(string fileName)
    {
        selectedFileName = fileName;
        selectedFileText.text = "Selected File: " + selectedFileName;
    }

    public string GetSelectedFileName()
    {
        return selectedFileName;
    }
}
