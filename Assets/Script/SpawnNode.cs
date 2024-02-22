using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public class SpawnNode : MonoBehaviour
{
    private TextAsset _csvFile;
    public static List<string[]> _csvData = new List<string[]>();
    private GameObject[] NodeArray;
    private int[] spawnCheck;
    private GameObject UP;
    private GameObject DOWN;
    private GameObject RIGHT;
    private GameObject LEFT;

    private void Start() {

        DOWN = (GameObject)Resources.Load("DOWN");
        UP = (GameObject)Resources.Load("UP");
        RIGHT = (GameObject)Resources.Load("RIGHT");
        LEFT = (GameObject)Resources.Load("LEFT");

        

        _csvFile = Resources.Load("Hitorigotsu2") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while(reader.Peek() != -1){
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

         for(int i = 1; i < _csvData.Count; i++){
                Debug.Log("TIme:::" + _csvData[i][0] + ",  UP::::" + _csvData[i][1] + ",  DOWN::::" + _csvData[i][2] + ",  RIGHT::::" + _csvData[i][3] + ",  LEFT::::" + _csvData[i][4]);
        }

        NodeArray = new GameObject[_csvData.Count];
        spawnCheck = new int[_csvData.Count];
        for (int i = 0; i < _csvData.Count; i++)
        {
            spawnCheck[i] = 0;        
        }




    }


    void Update()
    {
        if (GameManager.gameContinuing == true)
        {
            for (int i = 1; i < _csvData.Count; i++)
            {
                Debug.Log(_csvData[i][0]);
                if (Counter.timeFromStart > float.Parse(_csvData[i][0]) - 6.353295)
                {
                    if (spawnCheck[i] == 0)
                    {
                        Debug.Log(_csvData[i][1]);
                        if (int.Parse(_csvData[i][1]) == 1)
                        {
                            NodeArray[i] = (GameObject)Instantiate(UP, new Vector3(0f, 0f, 67f), Quaternion.Euler(0f, 90f, -90f));
                        }
                        if(int.Parse(_csvData[i][2]) == 1){
                            NodeArray[i] = (GameObject)Instantiate(DOWN, new Vector3(3.7f, 0f, 67f), Quaternion.Euler(0f, 90f, 90f));
                        }
                        if(int.Parse(_csvData[i][3]) == 1){
                            NodeArray[i] = (GameObject)Instantiate(RIGHT, new Vector3(7.4f, 1f, 67f), Quaternion.Euler(-90f, 90f, 90f));
                        }
                        if(int.Parse(_csvData[i][4]) == 1){
                            NodeArray[i] = (GameObject)Instantiate(LEFT, new Vector3(-3.7f, 1f, 67f), Quaternion.Euler(90f, 90f, 90f));
                        }
                        
                        spawnCheck[i] = 1;
                        
                    }
                }
            }
        }
    }
}