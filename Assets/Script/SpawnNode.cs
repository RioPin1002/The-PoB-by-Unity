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
    private GameObject InNode;
    private GameObject ExNode;

    private void Start() {

        ExNode = (GameObject)Resources.Load("Exhale");
        InNode = (GameObject)Resources.Load("Inhale");

        

        _csvFile = Resources.Load("Hitorigotsu") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        while(reader.Peek() != -1){
            string line = reader.ReadLine();
            _csvData.Add(line.Split(','));
        }

         for(int i = 0; i < _csvData.Count; i++){
                Debug.Log("TIme:::" + _csvData[i][0] + ",  NodeType::::" + _csvData[i][1]);
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
            for (int i = 0; i < _csvData.Count; i++)
            {
                if (Counter.timeFromStart > float.Parse(_csvData[i][0]) - 6.353295)
                {
                    if (spawnCheck[i] == 0)
                    {
                        if (int.Parse(_csvData[i][1]) == 1)
                        {
                            NodeArray[i] = (GameObject)Instantiate(InNode, new Vector3(0f, 0f, 67f), Quaternion.Euler(0f, 90f, -90f));

                        } else {
                            NodeArray[i] = (GameObject)Instantiate(ExNode, new Vector3(0f, 0f, 67f), Quaternion.Euler(0f, 90f, 90f));
                        }
                        
                        spawnCheck[i] = 1;
                        
                    }
                }
            }
        }
    }
}