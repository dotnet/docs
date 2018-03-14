//<snippet0>
using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;

namespace Examples.NegotiateStreamExample
{
    public class ASynchronousAuthenticatingTcpClient 
    {   
        static TcpClient client = null;

        public static void Main(String[] args)  
        {
    //<snippet2>
    //<snippet1>
            // Establish the remote endpoint for the socket.
            // For this example, use the local machine.
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            // Client and server use port 11000. 
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            // Create a TCP/IP socket.
            client = new TcpClient();
            // Connect the socket to the remote endpoint.
            client.Connect(remoteEP);
            Console.WriteLine("Client connected to {0}.", remoteEP.ToString());
            // Ensure the client does not close when there is 
            // still data to be sent to the server.
            client.LingerState = (new LingerOption(true, 0));
    //<snippet3>
            // Request authentication.
            NetworkStream clientStream = client.GetStream();
            NegotiateStream authStream = new NegotiateStream(clientStream, false); 
    //</snippet1>        
            // Pass the NegotiateStream as the AsyncState object 
            // so that it is available to the callback delegate.
            IAsyncResult ar = authStream.BeginAuthenticateAsClient(
                new AsyncCallback(EndAuthenticateCallback),
                authStream
                );
    //</snippet2>
            Console.WriteLine("Client waiting for authentication...");
            // Wait until the result is available.
            ar.AsyncWaitHandle.WaitOne();
            // Display the properties of the authenticated stream.
            AuthenticatedStreamReporter.DisplayProperties(authStream);
            // Send a message to the server.
            // Encode the test data into a byte array.
            byte[] message = Encoding.UTF8.GetBytes("Hello from the client.");
            ar = authStream.BeginWrite(message, 0, message.Length,
                new AsyncCallback(EndWriteCallback),
                authStream);
    //</snippet3>
            ar.AsyncWaitHandle.WaitOne();
            Console.WriteLine("Sent {0} bytes.", message.Length);
            // Close the client connection.
            authStream.Close();
            Console.WriteLine("Client closed.");
        }
    //<snippet5>
        // The following method is called when the authentication completes.
        public static void EndAuthenticateCallback (IAsyncResult ar)
        {
            Console.WriteLine("Client ending authentication...");
            NegotiateStream authStream = (NegotiateStream) ar.AsyncState;
            Console.WriteLine("ImpersonationLevel: {0}", authStream.ImpersonationLevel);

            // End the asynchronous operation.
            authStream.EndAuthenticateAsClient(ar);
        }
    //</snippet5>
    //<snippet4>
        // The following method is called when the write operation completes.
        public static void EndWriteCallback (IAsyncResult ar)
        {
            Console.WriteLine("Client ending write operation...");
            NegotiateStream authStream = (NegotiateStream) ar.AsyncState;

            // End the asynchronous operation.
            authStream.EndWrite(ar);
        }
    //</snippet4>
    }
    //<snippet6>

    // The following class displays the properties of an authenticatedStream.
    public class AuthenticatedStreamReporter
{
    public static void DisplayProperties(AuthenticatedStream stream)
   {
        Console.WriteLine("IsAuthenticated: {0}", stream.IsAuthenticated);
        Console.WriteLine("IsMutuallyAuthenticated: {0}", stream.IsMutuallyAuthenticated);
        Console.WriteLine("IsEncrypted: {0}", stream.IsEncrypted);
        Console.WriteLine("IsSigned: {0}", stream.IsSigned);
        Console.WriteLine("IsServer: {0}", stream.IsServer);
    }
}
    //</snippet6>
}
//</snippet0>

