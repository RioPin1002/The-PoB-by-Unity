using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using System.IO;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    private TextAsset _csvFile;
    public static List<string[]> _csvData = new List<string[]>();
    private GameObject[] NodeArray;
    private int[] spawnCheck;
    private GameObject Node;

    private void Start() {

        Node = (GameObject)Resources.Load("node");

        

        _csvFile = Resources.Load("TestCSV 2") as TextAsset;
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
                        NodeArray[i] = (GameObject)Instantiate(Node, new Vector3(0f, 1f, 67f), Quaternion.identity);
                        spawnCheck[i] = 1;
                        NodeMoving nodeMovingComponent = NodeArray[i].GetComponent<NodeMoving>();
                        
                        if (nodeMovingComponent != null)
                        {
                            if (int.Parse(_csvData[i][1]) == 0)
                            {
                                nodeMovingComponent.SetNodeColor(Color.red);
                            }
                            else if (int.Parse(_csvData[i][1]) == 1)
                            {
                                nodeMovingComponent.SetNodeColor(Color.blue);
                            }
                        }
                    }
                }
            }
        }
    }
}