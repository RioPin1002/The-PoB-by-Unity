using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using UnityEngine.UI;

public class UDP : MonoBehaviour 
{
    UdpClient udp;
    IPEndPoint remoteEP;

    public static int datacopy = 0;

    void Start() 
    {
        int LOCAL_PORT = 50007;  // 受信するポート番号
        udp = new UdpClient(LOCAL_PORT);
        udp.Client.ReceiveTimeout = 2000;  // 受信のタイムアウトを2秒に設定
    }

    void Update() 
    {
        try 
        {
            if (udp.Available > 0)  // データが受信可能か確認
            {
                byte[] data = udp.Receive(ref remoteEP);  // データを受信
                string text = Encoding.UTF8.GetString(data);  // 文字列に変換
                datacopy = Convert.ToInt32(text);
                
                
            }
        } 
        catch (SocketException e) 
        {
            if (e.SocketErrorCode != SocketError.TimedOut)
            {
                Debug.LogError("ソケットエラー: " + e);  // エラーがタイムアウト以外の場合にログに表示
            }
        }
    }

    void OnApplicationQuit() 
    {
        if (udp != null)
        {
            udp.Close();  // アプリケーション終了時にUDPクライアントを閉じる
        }
    }
}
