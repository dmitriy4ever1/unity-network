using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using System.Collections.Generic;

public class WsClient : MonoBehaviour
{
    WebSocket ws;
    public Text msgText;
    List<string> messages = new List<string>();
    public string remoteHost;
    private void Start()
    {
        ws = new WebSocket(remoteHost);
        ws.Connect();

        ws.OnMessage += (sender, e) =>
        {
            byte[] r = e.RawData;
            string s = System.Text.Encoding.UTF8.GetString(r);
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + s);
            messages.Add(s);
       //     messages.Add(e.Data);
            
        };
        ws.OnError += (sender, err) =>
        {
            Debug.Log("error " + err.Message);
            Debug.Log("ERR");
        };
        print("connected to ws: " + ws);
    }


    public void Submit(string mssg)
    {
        ws.Send(mssg);
    }

    private void Update()
    {
        if (ws == null)
        {
            return;
        }
      
        if(messages.Count > 0)
        {
            //print(messages.Count+" "+msg);
            
            msgText.text += "\n" + messages[0];
            messages.RemoveAt(0);
        }
    }
}