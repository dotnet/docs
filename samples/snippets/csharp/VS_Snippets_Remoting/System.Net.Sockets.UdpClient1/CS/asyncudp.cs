using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Permissions;
using System.Threading;

class MyUdpClientF
{
    static int s_listenPort = 13000;

    public static void Main(String[] args)
    {
        // Parse arguments
        string server;
        string message = "This is a test!";
        bool isServer;
        int sendMethodIndex = 1; // Which SendMessage* method to call (1/2/3)

        if (args.Length == 0)
        {
            server = "localhost";
            isServer = false;
        }
        else if (args.Length > 4)
        {
            Console.WriteLine("Usage: asyncudp [s|c] [host name] [message] [send method index]");
            return;
        }
        else
        {
            isServer = (args[0] == "s");
            server = (args.Length >= 2) ? args[1] : "";
            if (args.Length >= 3)
            {
                message = args[2];
            }
            if (args.Length >= 4)
            {
                sendMethodIndex = Convert.ToInt32(args[3]);
            }
        }

        if (isServer)
        {
            ReceiveMessages();
        }
        else
        {
            switch (sendMethodIndex)
            {
                case 1: 
                    SendMessage1(server, message);
                    break;
                case 2: 
                    SendMessage2(server, message);
                    break;
                case 3:
                    SendMessage3(server, message);
                    break;
            }
        }
    }

//<snippet1>
    public struct UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
    }

    public static bool messageReceived = false;

    public static void ReceiveCallback(IAsyncResult ar)
    {
        UdpClient u = ((UdpState)(ar.AsyncState)).u;
        IPEndPoint e = ((UdpState)(ar.AsyncState)).e;

        byte[] receiveBytes = u.EndReceive(ar, ref e);
        string receiveString = Encoding.ASCII.GetString(receiveBytes);

        Console.WriteLine($"Received: {receiveString}");
        messageReceived = true;
    }

    public static void ReceiveMessages()
    {
        // Receive a message and write it to the console.
        IPEndPoint e = new IPEndPoint(IPAddress.Any, s_listenPort);
        UdpClient u = new UdpClient(e);

        UdpState s = new UdpState();
        s.e = e;
        s.u = u;

        Console.WriteLine("listening for messages");
        u.BeginReceive(new AsyncCallback(ReceiveCallback), s);

        // Do some work while we wait for a message. For this example, we'll just sleep
        while (!messageReceived)
        {
            Thread.Sleep(100);
        }
    }
//</snippet1>

//<snippet2>
    public static bool messageSent = false;

    public static void SendCallback(IAsyncResult ar)
    {
        UdpClient u = (UdpClient)ar.AsyncState;

        Console.WriteLine($"number of bytes sent: {u.EndSend(ar)}");
        messageSent = true;
    }
//</snippet2>

//<snippet3>
    static void SendMessage1(string server, string message)
    {
        // create the udp socket
        UdpClient u = new UdpClient();

        u.Connect(server, s_listenPort);
        byte[] sendBytes = Encoding.ASCII.GetBytes(message);

        // send the message
        // the destination is defined by the call to .Connect()
        u.BeginSend(sendBytes, sendBytes.Length, new AsyncCallback(SendCallback), u);

        // Do some work while we wait for the send to complete. For this example, we'll just sleep
        while (!messageSent)
        {
            Thread.Sleep(100);
        }
    }
//</snippet3>

//<snippet4>
    static void SendMessage2(string server, string message)
    {
        // create the udp socket
        UdpClient u = new UdpClient();
        byte[] sendBytes = Encoding.ASCII.GetBytes(message);

        // resolve the server name
        IPHostEntry heserver = Dns.GetHostEntry(server);

        IPEndPoint e = new IPEndPoint(heserver.AddressList[0], s_listenPort);

        // send the message
        // the destination is defined by the IPEndPoint
        u.BeginSend(sendBytes, sendBytes.Length, e, new AsyncCallback(SendCallback), u);

        // Do some work while we wait for the send to complete. For this example, we'll just sleep
        while (!messageSent)
        {
            Thread.Sleep(100);
        }
    }
//</snippet4>

//<snippet5>
    static void SendMessage3(string server, string message)
    {
        // create the udp socket
        UdpClient u = new UdpClient();

        byte[] sendBytes = Encoding.ASCII.GetBytes(message);

        // send the message
        // the destination is defined by the server name and port
        u.BeginSend(sendBytes, sendBytes.Length, server, s_listenPort, new AsyncCallback(SendCallback), u);

        // Do some work while we wait for the send to complete. For this example, we'll just sleep
        while (!messageSent)
        {
            Thread.Sleep(100);
        }
    }
//</snippet5>
}
