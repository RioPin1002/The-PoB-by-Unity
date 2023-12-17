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
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        int LOCAL_LPORT = 50007;

        udp = new UdpClient(LOCAL_LPORT);
        udp.Client.ReceiveTimeout = 1;
    }

    // Update is called once per frame
    void Update()
    {
        IPEndPoint remoteEP = null;
        byte[] data = udp.Receive(ref remoteEP);
        string text = Encoding.UTF8.GetString(data);
        Debug.Log(text);
    }
}
