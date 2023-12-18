using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class CatchInputDataByPython : MonoBehaviour
{
    static UdpClient udp;
    public static int detect = 0;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        int LOCAL_LPORT = 50007;

        try
        {
            udp = new UdpClient(LOCAL_LPORT);
            udp.Client.ReceiveTimeout = 1;
        }
        catch (SocketException e)
        {
            Debug.LogError($"SocketException: {e.SocketErrorCode}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        detect = 0;
        try
        {
            IPEndPoint remoteEP = null;
            byte[] data = udp.Receive(ref remoteEP);
            string text = Encoding.UTF8.GetString(data);
            detect = int.Parse(text);
            Debug.Log(detect);
        }
        catch (SocketException e)
        {
            if (e.SocketErrorCode == SocketError.TimedOut)
            {
                
            }
            else
            {
                
            }
        }
    }
}
