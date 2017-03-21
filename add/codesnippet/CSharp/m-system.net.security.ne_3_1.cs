        public static void Main(String[] args)  
        {
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