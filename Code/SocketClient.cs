using UnityEngine;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;

public class SocketClient : MonoBehaviour
{
    private TcpClient tcpClient;
    private NetworkStream networkStream;
    private Thread receiveThread;
    private Vector2 position;  // Bruger Vector2 for 2D

    void Start()
    {
        // Start en ny tråd til at modtage data fra serveren
        receiveThread = new Thread(new ThreadStart(ConnectToServer));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    void Update()
    {
        // Brug positionen modtaget fra serveren
        transform.position = new Vector3(position.x, position.y, 0);  // Z = 0, da vi arbejder i 2D
    }

    void ConnectToServer()
    {
        try
        {
            // Opret forbindelse til serveren
            tcpClient = new TcpClient("10.148.139.171", 65432);  // IP og port
            networkStream = tcpClient.GetStream();

            while (true)
            {
                // Modtag data fra serveren
                byte[] buffer = new byte[1024];
                int bytesRead = networkStream.Read(buffer, 0, buffer.Length);

                if (bytesRead > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    // Ekstraher positionen (forventet format: "x, y")
                    ParsePosition(data);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Forbindelsesfejl: " + e.Message);
        }
    }
    void ParsePosition(string data)
    {
        try
        {
            // Ekstraher position fra den tekststräng, der er modtaget
            string[] split = data.Split(',');

            // Konverter string til float og sæt position
            float x = float.Parse(split[0].Trim());
            float y = float.Parse(split[1].Trim());

            position = new Vector2(x, y);
        }
        catch (Exception e)
        {
            Debug.LogError("Fejl ved parsing af position: " + e.Message);
        }
    }

    void OnApplicationQuit()
    {
        // Luk forbindelsen, når spillet afsluttes
        if (tcpClient != null)
        {
            networkStream.Close();
            tcpClient.Close();
        }
    }
}