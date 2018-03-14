using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Security.Permissions;
using System.Threading;


class MyUdpClient
{
  static int listenPort = 13000;

  public static void Main(String[] args)
  {
    // Parse arguments
    String server = "";
    String message = "This is a test!";;
    bool isServer = false;
    int sendMethod = 1; // n called SendMessagen

    if(args.Length == 0)
    {
      server = "localhost";
      isServer = false;
    }
    else if(args.Length == 1)
    {
      isServer = args[0]=="s" ? true : false;
    }
    else if(args.Length == 2)
    {
      isServer = args[0]=="s" ? true : false;
      server = args[1];
    }
    else if(args.Length == 3)
    {
      isServer = args[0]=="s" ? true : false;
      server = args[1];
      message = args[2];
    }
    else if(args.Length == 4)
    {
      isServer = args[0]=="s" ? true : false;
      server = args[1];
      message = args[2];
      sendMethod = Convert.ToInt32(args[3]);
    }
    else
    {
      Console.WriteLine("Usage: asyncudp [s|c] [host name] [message] [send method]");
      return;
    }

    if (isServer)
    {
      ReceiveMessages();
    }
    else
    {
      switch (sendMethod)
      {
        case 1: 
          SendMessage1(server,message);
          break;
        case 2: 
          SendMessage2(server,message);
          break;
        case 3:     UdpClient u = new UdpClient();

          SendMessage3(server,message);
          break;
      }
    }
  }


    UdpClient u = new UdpClient();

  public struct UdpState
  {
    public UdpClient u;
    public IPEndPoint e;
  }
//<snippet1>
  public static bool messageReceived = false;

  public static void ReceiveCallback(IAsyncResult ar)
  {
    UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
    IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;

    Byte[] receiveBytes = u.EndReceive(ar, ref e);
    string receiveString = Encoding.ASCII.GetString(receiveBytes);

    Console.WriteLine("Received: {0}", receiveString);
    messageReceived = true;
  }

  public static void ReceiveMessages()
  {
    // Receive a message and write it to the console.
    IPEndPoint e = new IPEndPoint(IPAddress.Any, listenPort);
    UdpClient u = new UdpClient(e);

    UdpState s = new UdpState();
    s.e = e;
    s.u = u;

    Console.WriteLine("listening for messages");
    u.BeginReceive(new AsyncCallback(ReceiveCallback), s);

    // Do some work while we wait for a message. For this example,
    // we'll just sleep
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

    Console.WriteLine("number of bytes sent: {0}", u.EndSend(ar));
    messageSent = true;
  }
//</snippet2>

//<snippet3>
  static void SendMessage1(string server, string message)
  {
    // create the udp socket
    UdpClient u = new UdpClient();

    u.Connect(server, listenPort);
    Byte [] sendBytes = Encoding.ASCII.GetBytes(message);

    // send the message
    // the destination is defined by the call to .Connect()
    u.BeginSend(sendBytes, sendBytes.Length, 
                new AsyncCallback(SendCallback), u);

    // Do some work while we wait for the send to complete. For 
    // this example, we'll just sleep
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
    Byte [] sendBytes = Encoding.ASCII.GetBytes(message);

    // resolve the server name
    IPHostEntry heserver = Dns.GetHostEntry(server);

    IPEndPoint e = new IPEndPoint(heserver.AddressList[0], listenPort);

    // send the message
    // the destination is defined by the IPEndPoint
    u.BeginSend(sendBytes, sendBytes.Length, e,
                new AsyncCallback(SendCallback), u);

    // Do some work while we wait for the send to complete. For 
    // this example, we'll just sleep
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

    Byte [] sendBytes = Encoding.ASCII.GetBytes(message);

    // send the message
    // the destination is defined by the server name and port
    u.BeginSend(sendBytes, sendBytes.Length, server, listenPort,
                new AsyncCallback(SendCallback), u);

    // Do some work while we wait for the send to complete. For 
    // this example, we'll just sleep
    while (!messageSent)
    {
      Thread.Sleep(100);
    }
  }
//</snippet5>
}