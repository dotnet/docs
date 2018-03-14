using System;
using System.Text;
using System.Net; 
using System.Net.Sockets;

public class MyUdpClientTestClass{
//<Snippet1>
    public static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("you must specify a port number!");
            return;
        }

        UdpClient uClient = new UdpClient(Convert.ToInt32(args[0]));
        Socket uSocket = uClient.Client;

        // use the underlying socket to enable broadcast.
        uSocket.SetSocketOption(SocketOptionLevel.Socket, 
                      SocketOptionName.Broadcast, 1);
    }
//</Snippet1>
}
