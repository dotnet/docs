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