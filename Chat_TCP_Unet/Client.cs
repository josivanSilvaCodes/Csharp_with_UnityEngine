using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;


public class Client : MonoBehaviour
{
    public InputField typeText;
    public Text seeText;
    public Text serverText;


    public InputField h;
    public InputField p;
    public Text att;

    private bool socketReady = false;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;

    public void ConnectToServer()
    {
        if (socketReady)
            return;

        string host = "192.168.1.102"; 
        int port = 5000;

        host = h.text;
        port = int.Parse(p.text);

        Debug.Log("Host: " + h.text + ", Porta: " + int.Parse(p.text));
        att.text = "Atenção --> " + " Host: " + h.text + ", Porta: " + int.Parse(p.text);

        try
        {
            socket = new TcpClient(h.text, int.Parse(p.text));
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            socketReady = true;

        }
        catch(System.Exception e)
        {
            Debug.Log("Socket error: " + e.Message);
        }


    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                string data = reader.ReadLine();
                if (data != null)
                    OnIncomingData(data);
            }
        }
    }

    private void OnIncomingData(string data)
    {
        Debug.Log("Server : " + data);
        serverText.text = data;
    }

    private void Send(string data)
    {
        if (!socketReady)
            return;

        writer.WriteLine(data);
        writer.Flush();
    }

    public void OnSendButton()
    {
        string msg = typeText.text;
        Send(msg);
        seeText.text = msg;
    }
}
