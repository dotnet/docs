using System;
using System.Text;
using System.Net; 
using System.Net.Sockets;

public class Example
{
    [STAThread]
    static void Main()
    {
//<Snippet1>
        TcpClient client = new TcpClient();
        Socket s = client.Client;

        if (!s.Connected)
        {
            s.SetSocketOption(SocketOptionLevel.Socket, 
                         SocketOptionName.ReceiveBuffer, 16384);
            Console.WriteLine(
                "client is not connected, ReceiveBuffer set\n");
        }
        else
           Console.WriteLine("client is connected");
//</Snippet1>
    }
}