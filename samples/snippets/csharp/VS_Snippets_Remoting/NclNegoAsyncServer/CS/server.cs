//<snippet0>
using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Principal;
using System.Text;
using System.IO;
using System.Threading;

namespace Examples.NegotiateStreamExample
{
    public class AsynchronousAuthenticatingTcpListener 
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
                Console.WriteLine("Client connected.");
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

            }
        
        }
        //<snippet1>
        public static void AuthenticateClient(TcpClient clientRequest)
        {
            NetworkStream stream = clientRequest.GetStream(); 
            // Create the NegotiateStream.
            NegotiateStream authStream = new NegotiateStream(stream, false); 
            // Save the current client and NegotiateStream instance 
            // in a ClientState object.
            ClientState cState = new ClientState(authStream, clientRequest);
            // Listen for the client authentication request.
            authStream.BeginAuthenticateAsServer (
                new AsyncCallback(EndAuthenticateCallback),
                cState
                );
            // Wait until the authentication completes.
            cState.Waiter.WaitOne();
            cState.Waiter.Reset();
            authStream.BeginRead(cState.Buffer, 0, cState.Buffer.Length, 
                   new AsyncCallback(EndReadCallback), 
                   cState);
            cState.Waiter.WaitOne();
            // Finished with the current client.
            authStream.Close();
            clientRequest.Close();
        }
        //</snippet1>    
        // The following method is invoked by the
        // BeginAuthenticateAsServer callback delegate.

      //<snippet2>
        public static void EndAuthenticateCallback (IAsyncResult ar)
        {
            // Get the saved data.
            ClientState cState = (ClientState) ar.AsyncState;
            TcpClient clientRequest = cState.Client;
            NegotiateStream authStream = (NegotiateStream) cState.AuthenticatedStream;
            Console.WriteLine("Ending authentication.");
            // Any exceptions that occurred during authentication are
            // thrown by the EndAuthenticateAsServer method.
            try 
            {
                // This call blocks until the authentication is complete.
                authStream.EndAuthenticateAsServer(ar);
            }
            catch (AuthenticationException e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Authentication failed - closing connection.");
                cState.Waiter.Set();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Closing connection.");
                cState.Waiter.Set();
                return;
            }
            // Display properties of the authenticated client.
            IIdentity id = authStream.RemoteIdentity;
            Console.WriteLine("{0} was authenticated using {1}.", 
                id.Name, 
                id.AuthenticationType
                );
            cState.Waiter.Set();

    }
//</snippet2>
//<snippet3>
        public static void EndReadCallback(IAsyncResult ar)
        {
            // Get the saved data.
            ClientState cState = (ClientState) ar.AsyncState;
            TcpClient clientRequest = cState.Client;
            NegotiateStream authStream = (NegotiateStream) cState.AuthenticatedStream; 
            // Get the buffer that stores the message sent by the client.
            int bytes = -1;
            // Read the client message.
            try
            {
                    bytes = authStream.EndRead(ar);
                    cState.Message.Append(Encoding.UTF8.GetChars(cState.Buffer, 0, bytes));
                    if (bytes != 0)
                    {
                         authStream.BeginRead(cState.Buffer, 0, cState.Buffer.Length, 
                               new AsyncCallback(EndReadCallback), 
                               cState);
                               return;
                 }
            }
            catch (Exception e)
            {
                // A real application should do something
                // useful here, such as logging the failure.
                Console.WriteLine("Client message exception:");
                Console.WriteLine(e);
                cState.Waiter.Set();
                return;
            }
            IIdentity id = authStream.RemoteIdentity;
            Console.WriteLine("{0} says {1}", id.Name, cState.Message.ToString());
            cState.Waiter.Set();
        }
            //</snippet3>
    }
    // ClientState is the AsyncState object.
    internal class ClientState
    {
        private AuthenticatedStream authStream = null;
        private  TcpClient client = null;
        byte[] buffer = new byte[2048];
        StringBuilder message = null;
        ManualResetEvent waiter = new ManualResetEvent(false);
        internal ClientState(AuthenticatedStream a, TcpClient theClient)
        {
            authStream = a;
            client = theClient;
        }
        internal TcpClient Client
        { 
            get { return client;}
        }
        internal AuthenticatedStream AuthenticatedStream
        {
            get { return authStream;}
        }
        internal byte[] Buffer
        {
              get { return buffer;}
        }
        internal StringBuilder Message
        {
            get 
            { 
                if (message == null)
                    message = new StringBuilder();
                return message;
             }
        }
        internal ManualResetEvent Waiter
        {
            get 
            { 
                return waiter;
             }
        }
    }
}
//</snippet0>

