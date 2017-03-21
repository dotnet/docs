            // Request authentication.
            NetworkStream clientStream = client.GetStream();
            NegotiateStream authStream = new NegotiateStream(clientStream, false); 
            // Pass the NegotiateStream as the AsyncState object 
            // so that it is available to the callback delegate.
            IAsyncResult ar = authStream.BeginAuthenticateAsClient(
                new AsyncCallback(EndAuthenticateCallback),
                authStream
                );
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