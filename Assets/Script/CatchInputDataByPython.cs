using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using JetBrains.Annotations;

public class CatchInputDataByPython : MonoBehaviour
{
    static UdpClient udp;
    public static int[] detect = new int[4];
    public static string detectNumString;
    public static int detectNUM;

    // Start is called before the first frame update
    void Start()
    {
        detect[0] = 0;
        detect[1] = 0;
        detect[2] = 0;
        detect[3] = 0;
    }

    // Update is called once per frame
    void Update()
{
    
    for (int i = 0; i < 4; i++)
        {
            detect[i] = 0;
        }

    // キー入力を検知して detectNumString を更新
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        detect[0] = 1;
        Debug.Log("↑");
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
        detect[1] = 1;
        Debug.Log("↓");
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
        detect[2] = 1;
        Debug.Log("→");
    }
    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
        detect[3] = 1;
        Debug.Log("←");
    }

    // detectNumString を detect 配列に変換
    
}

}
