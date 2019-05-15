using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System;
using System.IO;

using UnityEngine.UI;

public class Server : MonoBehaviour
{
    public Text att;
    private List<ServerClient> clientsConnected;
    private List<ServerClient> clientsDisconnected;
    public Text areaText;
    public InputField sendText;
    public Text clientText;

    public int port = 5000;
    private TcpListener server;
    private bool serverStarted;
    
    /*
    private void Start()
    {
        clientsConnected = new List<ServerClient>();
        clientsDisconnected = new List<ServerClient>();
        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            StartListening();
            serverStarted = true;
            Debug.Log("Servidor iniciado na porta: " + port.ToString());
            att.text = "Atenção --> Servidor iniciado na porta: " + port.ToString();


        }
        catch(System.Exception e)
        {
            Debug.Log("Socket error: " + e.Message);
        }

    }
    */

    public void UpServer()
    {
        clientsConnected = new List<ServerClient>();
        clientsDisconnected = new List<ServerClient>();
        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            StartListening();
            serverStarted = true;
            Debug.Log("Servidor iniciado na porta: " + port.ToString());
            att.text = "Atenção --> Servidor iniciado na porta: " + port.ToString();


        }
        catch (System.Exception e)
        {
            Debug.Log("Socket error: " + e.Message);
        }

    }

    private void Update()
    {
        if (!serverStarted)
        {
            att.text = "Atenção --> Servidor desligado ou desconectado ";
            return;
        }

        foreach (ServerClient c in clientsConnected)
        {
            if (!IsConnected(c.tcp))
            {
                c.tcp.Close();
                clientsDisconnected.Add(c);
                continue;
            }
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string data = reader.ReadLine();

                    if (data != null)
                    {
                        OnIncomingData(c, data);
                       
                    }
                }

            }
        }
    }

    private void OnIncomingData(ServerClient c, string data)
    {
        Debug.Log(c.clientName + "Mensagem = " + data);
        clientText.text = data;
    }

    private bool IsConnected(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                {
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                }
                return true;
            }
            else
            {
                return false;
            }

        }
        catch
        {
            return false;
        }
    }

    private void StartListening()
    {
        server.BeginAcceptTcpClient( AcceptTcpClient, server );
    }

    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        clientsConnected.Add(new ServerClient(listener.EndAcceptTcpClient(ar)));
        StartListening();
        Broadcast(clientsConnected[clientsConnected.Count-1 ].clientName + " Conectou agora!", clientsConnected);
        att.text = "Atenção -->" + 
            clientsConnected[clientsConnected.Count-1 ].clientName + " Conectou agora, no servidor na porta: " + port;
    }

    private void Broadcast(string data, List<ServerClient> cl)
    {
        foreach (ServerClient c in cl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(c.tcp.GetStream());
                writer.WriteLine(data);
                writer.Flush();

            }
            catch (System.Exception e)
            {
                Debug.Log("Write error : " + e.Message + "to client" + c.clientName);
            }
        }
    }

    public void SendMsgToClients()
    {
        string data = sendText.text;
        Broadcast(data, clientsConnected);
        areaText.text = data;

    }
}

public class ServerClient
{
    public TcpClient tcp;
    public string clientName;

    public ServerClient(TcpClient clientSocket)
    {
        clientName = "Guest";
        tcp = clientSocket;
    }
}
