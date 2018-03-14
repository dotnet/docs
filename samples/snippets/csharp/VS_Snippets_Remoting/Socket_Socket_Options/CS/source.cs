using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Sync_Send_Receive
{
    public static void SetSocketOptions ()
    {
        IPHostEntry lipa = Dns.Resolve ("host.contoso.com");
        IPEndPoint lep = new IPEndPoint (lipa.AddressList[0], 11000);
        Socket s = new Socket (lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

//<Snippet1>
        // Send operations will time-out if confirmation 
        // is not received within 1000 milliseconds.
        s.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000);

        // The socket will linger for 10 seconds after Socket.Close is called.
        LingerOption lingerOption = new LingerOption (true, 10);

        s.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption);

//</Snippet1>                  
        s.Connect (lep);

        byte[] msg = Encoding.ASCII.GetBytes ("This is a test");

//<Snippet2>
        Console.WriteLine ("This application will timeout if Send does not return within " + Encoding.ASCII.GetString (s.GetSocketOption (SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 4)));

        // blocks until send returns
        int i = s.Send (msg);

        // blocks until read returns
        byte[] bytes = new byte[1024];

        s.Receive (bytes);

        //Display to the screen
        Console.WriteLine (Encoding.ASCII.GetString (bytes));
        s.Shutdown (SocketShutdown.Both);
        Console.WriteLine ("If data remains to be sent, this application will stay open for " + ((LingerOption)s.GetSocketOption (SocketOptionLevel.Socket, SocketOptionName.Linger)).LingerTime.ToString ());
        s.Close ();
//</Snippet2>
    }

    public static void CheckProperties ()
    {
        IPHostEntry lipa = Dns.Resolve ("host.contoso.com");
        IPEndPoint lep = new IPEndPoint (lipa.AddressList[0], 11000);

        //<Snippet3>
        Socket s = new Socket (lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        //Using the AddressFamily, SocketType, and ProtocolType properties.
        Console.WriteLine ("I just set the following properties of socket: " + "Address Family = " + s.AddressFamily.ToString () + "\nSocketType = " + s.SocketType.ToString () + "\nProtocolType = " + s.ProtocolType.ToString ());

//</Snippet3>
//<Snippet4>
        s.Connect (lep);

        // Using the RemoteEndPoint property.
        Console.WriteLine ("I am connected to " + IPAddress.Parse (((IPEndPoint)s.RemoteEndPoint).Address.ToString ()) + "on port number " + ((IPEndPoint)s.RemoteEndPoint).Port.ToString ());

        // Using the LocalEndPoint property.
        Console.WriteLine ("My local IpAddress is :" + IPAddress.Parse (((IPEndPoint)s.LocalEndPoint).Address.ToString ()) + "I am connected on port number " + ((IPEndPoint)s.LocalEndPoint).Port.ToString ());

//</Snippet4>
        //<Snippet5>
        //Use low level method IOControl to set this socket to blocking mode.
        int code = unchecked((int)0x8004667E);
        byte[] inBuf = new byte[4];

        inBuf[0] = 0;

        byte[] outBuf = new byte[4];

        s.IOControl (code, inBuf, outBuf);

        //Check to see that this worked.
        if (s.Blocking)
        {
            Console.WriteLine ("Socket was set to Blocking mode successfully");
        }
//</Snippet5>
    }

    public static void Main ()
    {
    }
}

