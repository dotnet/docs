            // Create a TCP/IP client socket.
            // machineName is the host running the server application.
            TcpClient client = new TcpClient(machineName,443);
            Console.WriteLine("Client connected.");
            // Create an SSL stream that will close the client's stream.
            SslStream sslStream = new SslStream(
                client.GetStream(), 
                false, 
                new RemoteCertificateValidationCallback (ValidateServerCertificate), 
                null
                );
            // The server name must match the name on the server certificate.
            try 
            {
                sslStream.AuthenticateAsClient(serverName);
            } 
            catch (AuthenticationException e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null)
                {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine ("Authentication failed - closing the connection.");
                client.Close();
                return;
            }