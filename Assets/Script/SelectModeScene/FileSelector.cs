using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FileSelector : MonoBehaviour
{
    public FileDisplay fileDisplay;
    public TextMeshProUGUI resultText;  // 選択結果を表示するTextMeshPro

    public void OnSelectButtonClick()
    {
        string selectedFile = fileDisplay.GetSelectedFileName();
        if (!string.IsNullOrEmpty(selectedFile))
        {
            resultText.text = "Selected File: " + selectedFile;
            Debug.Log("Selected File: " + selectedFile);
            // ここで選択されたファイル名を他の処理に渡すことができます。
        }
        else
        {
            resultText.text = "No file selected.";
        }
    }
}
