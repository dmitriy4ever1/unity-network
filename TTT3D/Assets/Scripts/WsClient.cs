using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;
using System.Collections.Generic;

public class WsClient : MonoBehaviour
{
    static GameObject EventSystem;
    Block blx;
    static WebSocket ws;
    public Text msgText;
    List<string> messages = new List<string>();
    public string remoteHost;
    object sender1;
    object e1;
    private void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        blx = (Block)EventSystem.GetComponent(typeof(Block));

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


    public static void Submit(string mssg)
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
            string remoteMsg = messages[0];
            print(remoteMsg);

            int x = remoteMsg[0]-'0';
            int y = remoteMsg[2]-'0';
            int z = remoteMsg[4]-'0';
            char who = remoteMsg[6];
            Matrix.OnRemoteMessage(x, y, z, who);
            msgText.text += "\n" + messages[0];
            messages.RemoveAt(0);
            /*
            if (Block.collor == 1)
                Block.collor = 2;
            else
                Block.collor = 1;*/
        }
    }
}