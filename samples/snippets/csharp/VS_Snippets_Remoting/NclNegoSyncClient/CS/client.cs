   //<snippet0>
using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Principal;

namespace Examples.NegotiateStreamExample
{
    public class SynchronousAuthenticatingTcpClient 
    {
        //<snippet4>
        public static void Main(String[] args)  
        {
                //<snippet3>
            // Establish the remote endpoint for the socket.
            // For this example, use the local machine.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            // Client and server use port 11000. 
            IPEndPoint remoteEP = new IPEndPoint(ipAddress,11000);
            // Create a TCP/IP socket.
           TcpClient client = new TcpClient();
            // Connect the socket to the remote endpoint.
            client.Connect(remoteEP);
            Console.WriteLine("Client connected to {0}.",
                remoteEP.ToString());
            // Ensure the client does not close when there is 
            // still data to be sent to the server.
            client.LingerState = (new LingerOption(true,0));
            // Request authentication.
            NetworkStream clientStream = client.GetStream();
            NegotiateStream authStream = new NegotiateStream(clientStream); 
            // Request authentication for the client only (no mutual authentication).
            // Authenicate using the client's default credetials.
            // Permit the server to impersonate the client to access resources on the server only.
            // Request that data be transmitted using encryption and data signing.
            authStream.AuthenticateAsClient(
                 (NetworkCredential) CredentialCache.DefaultCredentials, 
                 "",
                 ProtectionLevel.EncryptAndSign,
                 TokenImpersonationLevel.Impersonation);
           //</snippet3>
            DisplayAuthenticationProperties(authStream);
            DisplayStreamProperties(authStream);
            if (authStream.CanWrite)
            {
                 // Encode the test data into a byte array.
                byte[] message = System.Text.Encoding.UTF8.GetBytes("Hello from the client.");
                authStream.Write(message, 0, message.Length);
          authStream.Flush();
                Console.WriteLine("Sent {0} bytes.", message.Length);
         }
         // Close the client connection.
            authStream.Close();
            Console.WriteLine("Client closed.");
            
    }
    //</snippet4>
    //<snippet2>
         static void DisplayStreamProperties(NegotiateStream stream)
        {
             Console.WriteLine("Can read: {0}", stream.CanRead);
             Console.WriteLine("Can write: {0}", stream.CanWrite);
             Console.WriteLine("Can seek: {0}", stream.CanSeek);
             try 
             {
                 // If the underlying stream supports it, display the length.
                 Console.WriteLine("Length: {0}", stream.Length);
             } catch (NotSupportedException)
             {
                     Console.WriteLine("Cannot get the length of the underlying stream.");
             }
             
             if (stream.CanTimeout)
             {
                 Console.WriteLine("Read time-out: {0}", stream.ReadTimeout);
                 Console.WriteLine("Write time-out: {0}", stream.WriteTimeout);
             }
        }
           //</snippet2>
           //<snippet1>
         static void DisplayAuthenticationProperties(NegotiateStream stream)
        {
             Console.WriteLine("IsAuthenticated: {0}", stream.IsAuthenticated);
            Console.WriteLine("IsMutuallyAuthenticated: {0}", stream.IsMutuallyAuthenticated);
            Console.WriteLine("IsEncrypted: {0}", stream.IsEncrypted);
            Console.WriteLine("IsSigned: {0}", stream.IsSigned);
            Console.WriteLine("ImpersonationLevel: {0}", stream.ImpersonationLevel);
            Console.WriteLine("IsServer: {0}", stream.IsServer);
        }
           //</snippet1>
    }
}
   //</snippet0>
 