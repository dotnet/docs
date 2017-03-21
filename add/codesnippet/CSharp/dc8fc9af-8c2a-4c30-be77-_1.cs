            // Server name must match the host name and the name on the host's certificate. 
            serverName = args[0];
            // Create a TCP/IP client socket.
            TcpClient client = new TcpClient(serverName,80);
            Console.WriteLine("Client connected.");
            // Create an SSL stream that will close the client's stream.
            SslStream sslStream = new SslStream(
                client.GetStream(), 
                false, 
                new RemoteCertificateValidationCallback (ValidateServerCertificate), 
                new LocalCertificateSelectionCallback(SelectLocalCertificate)
                );