//<Snippet1>
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Examples.System.Net
{
    public class TCPClientExample
    {
        public static void Main()
        {
//<Snippet2>
			// Create a client that will connect to a 
            // server listening on the contosoServer computer
            // at port 11000.
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("contosoServer", 11000);
            // Get the stream used to read the message sent by the server.
            NetworkStream networkStream = tcpClient.GetStream();
            // Set a 10 millisecond timeout for reading.
            networkStream.ReadTimeout = 10;
            // Read the server message into a byte buffer.
            byte[] bytes = new byte[1024];
            networkStream.Read(bytes, 0, 1024);
            //Convert the server's message into a string and display it.
            string data = Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Server sent message: {0}", data);
            networkStream.Close();
            tcpClient.Close();
//</Snippet2>
		}
    }
}
//</Snippet1>