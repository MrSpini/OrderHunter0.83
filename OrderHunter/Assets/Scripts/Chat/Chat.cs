using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.UI;

public class Chat : MonoBehaviour 
{   
    public Text Message;
    WebSocket ws = new WebSocket("ws://app-labs-crawlers.ru:9090");

    void Start()
    {
        ChatSocketConnect();
    }

    void Update()
    {
        ChatMessageBack();
    }

    void ChatSocketConnect()
    {  
        string name = (string)PlayerPrefs.GetString("Set-cookie");
        ws.SetCookie(new WebSocketSharp.Net.Cookie("laravel_session", name));
        print("connect");
        ws.Connect();
    }

    public void ChatMessageBack()
    {
        ws.OnMessage += (sender, e) =>
            {      
                print("test");
            };
    }

    public void ChatMessageOn()
    {
        ws.Send(Message.ToString());
    }
}
