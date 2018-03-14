//<Snippet1>
/**
* The following sample is intended to demonstrate how to use a
* TcpListener for synchronous communcation with a TCP client
* It creates a TcpListener that listens on the specified port (13000). 
* Any TCP client that wants to use this TcpListener has to explicitly connect 
* to an address obtained by the combination of the server
* on which this TcpListener is running and the port 13000.
* This TcpListener simply echoes back the message sent by the client
* after translating it into uppercase. 
* Refer to the related client in the TcpClient class. 
*/

using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class TcpListenerSample
{


    static void Main(string[] args)
    {
        try
        {
            // set the TcpListener on port 13000
            int port = 13000;
            TcpListener server = new TcpListener(IPAddress.Any, port);

            // Start listening for client requests
            server.Start();


            // Buffer for reading data
            byte[] bytes = new byte[1024];
            string data;

            //Enter the listening loop
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Perform a blocking call to accept requests.
                // You could also user server.AcceptSocket() here.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                i = stream.Read(bytes, 0, bytes.Length);

                while (i != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine(String.Format("Received: {0}", data));

                    // Process the data sent by the client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine(String.Format("Sent: {0}", data));

                    i = stream.Read(bytes, 0, bytes.Length);

                }

                // Shutdown and end connection
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }


        Console.WriteLine("Hit enter to continue...");
        Console.Read();
    }

}
//</Snippet1>
