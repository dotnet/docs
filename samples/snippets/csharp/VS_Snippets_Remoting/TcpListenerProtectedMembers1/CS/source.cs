using System;
using System.Net; 
using System.Net.Sockets;


public class TestClass
{
// <Snippet1>
    public static void listenerOption(string host, int port)
    {
        IPHostEntry server = Dns.Resolve(host);
        IPAddress ipAddress = server.AddressList[0];

        Console.WriteLine("listening on {0}, port {1}", ipAddress, port);
        TcpListener listener = new TcpListener(ipAddress, port);
        Socket listenerSocket = listener.Server;		

        LingerOption lingerOption = new LingerOption(true, 10);
        listenerSocket.SetSocketOption(SocketOptionLevel.Socket, 
                          SocketOptionName.Linger, 
                          lingerOption);

        // start listening and process connections here.
        listener.Start();

    }
// </Snippet1>

    public static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            listenerOption("localhost", 10042);
        }
        else
        {
            listenerOption(args[0], Convert.ToInt32(args[1]));
        }

        Console.WriteLine("enter to exit");
        Console.Read();

    }
}



