// <Snippet1>
using System;
using System.Net;
using System.Net.Sockets;

public class Server 
{
    static void Main() 
    {
        // This is a Windows Sockets 2 error code.
        const int WSAETIMEDOUT = 10060;

        Socket serverSocket;
        int bytesReceived, totalReceived = 0;
        byte[] receivedData = new byte[2000000];

        // Create random data to send to the client.
        byte[] dataToSend = new byte[2000000];
        new Random().NextBytes(dataToSend);

        IPAddress ipAddress =
            Dns.Resolve(Dns.GetHostName()).AddressList[0];

        IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 1800);

        // Create a socket and listen for incoming connections.
        using(Socket listenSocket = new Socket(
            AddressFamily.InterNetwork, SocketType.Stream, 
            ProtocolType.Tcp))
        {
            listenSocket.Bind(ipEndpoint);
            listenSocket.Listen(1);

            // Accept a connection and create a socket to handle it.
            serverSocket = listenSocket.Accept();
            Console.WriteLine("Server is connected.\n");
        }

        try
        {
            // Send data to the client.
            Console.Write("Sending data ... ");
            int bytesSent = serverSocket.Send(
                dataToSend, 0, dataToSend.Length, SocketFlags.None);
            Console.WriteLine("{0} bytes sent.\n", 
                bytesSent.ToString());

            // Set the timeout for receiving data to 2 seconds.
            serverSocket.SetSocketOption(SocketOptionLevel.Socket,
                SocketOptionName.ReceiveTimeout, 2000);

            // Receive data from the client.
            Console.Write("Receiving data ... ");
            try
            {
                do
                {
                    bytesReceived = serverSocket.Receive(receivedData,
                        0, receivedData.Length, SocketFlags.None);
                    totalReceived += bytesReceived;
                }
                while(bytesReceived != 0);
            }
            catch(SocketException e)
            {
                if(e.ErrorCode == WSAETIMEDOUT)
                {
                    // Data was not received within the given time.
                    // Assume that the transmission has ended.
                }
                else
                {
                    Console.WriteLine("{0}: {1}\n", 
                        e.GetType().Name, e.Message);
                }
            }
            finally
            {
                Console.WriteLine("{0} bytes received.\n",
                    totalReceived.ToString());
            }
        }
        finally
        {
            serverSocket.Shutdown(SocketShutdown.Both);
            Console.WriteLine("Connection shut down.");
            serverSocket.Close();
        }
    }
}
// </Snippet1>