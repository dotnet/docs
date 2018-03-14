using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.IO;
using System.Threading;

namespace Examples.NegotiateStreamExamples
{
    public class synchronousAuthenticatingTcpListener 
    {
        public static void Main() 
        {   
            // Create an IPv4 TCP/IP socket. 
            TcpListener listener = new TcpListener(IPAddress.Any, 11000);
            // Listen for incoming connections.
            listener.Start();
            while (true) 
            {
                TcpClient clientRequest = null;
                // Application blocks while waiting for an incoming connection.
                // Type CNTL-C to terminate the server.
                clientRequest = listener.AcceptTcpClient();
                // A client has connected. 
                try
                {
                    AuthenticateClient (clientRequest);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    continue;
                }
                Console.WriteLine("Client connected.");
            }
        
        }
        //<snippet1>
        public static void AuthenticateClient(TcpClient clientRequest)
        {
            NetworkStream stream = clientRequest.GetStream(); 
            // Create the NegotiateStream.
            NegotiateStream authStream = new NegotiateStream(stream, false);
            // Perform the server side of the authentication.
            authStream.AuthenticateAsServer();
            // Display properties of the authenticated client.
            IIdentity id = authStream.RemoteIdentity;
            Console.WriteLine("{0} was authenticated using {1}.", 
                id.Name, 
                id.AuthenticationType
                );
            // Read a message from the client.
            byte [] buffer = new byte[2048];
            int charLength = authStream.Read(buffer, 0, buffer.Length);
            string messageData = new String(Encoding.UTF8.GetChars(buffer, 0, buffer.Length));
           
            Console.WriteLine("READ {0}", messageData);
            // Finished with the current client.
            authStream.Close(); 
            // Close the client connection.
            clientRequest.Close();
        }
         //</snippet1>
    }
}
