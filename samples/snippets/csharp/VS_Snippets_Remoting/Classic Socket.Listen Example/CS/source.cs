using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

public class Sample
{
    static void CreateAndListen(int port, int backlog)
    {
// <Snippet1>
        // create the socket
        Socket listenSocket = new Socket(AddressFamily.InterNetwork, 
                                         SocketType.Stream,
                                         ProtocolType.Tcp);

        // bind the listening socket to the port
	IPAddress hostIP = (Dns.Resolve(IPAddress.Any.ToString())).AddressList[0];
        IPEndPoint ep = new IPEndPoint(hostIP, port);
        listenSocket.Bind(ep); 

        // start listening
        listenSocket.Listen(backlog);
// </Snippet1>
    }

    [STAThread]
    static void Main()
    {
        CreateAndListen(10042, 10);

        Console.WriteLine("enter to exit");
        Console.Read();
    }

}

