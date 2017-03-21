        static void AuthenticateCallback(IAsyncResult ar)
        {
            SslStream stream = (SslStream) ar.AsyncState;
            try 
            {
                stream.EndAuthenticateAsClient(ar);
                Console.WriteLine("Authentication succeeded.");
                Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, 
                    stream.CipherStrength);
                Console.WriteLine("Hash: {0} strength {1}", 
                    stream.HashAlgorithm, stream.HashStrength);
                Console.WriteLine("Key exchange: {0} strength {1}", 
                    stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength);
                Console.WriteLine("Protocol: {0}", stream.SslProtocol);
                // Encode a test message into a byte array.
                // Signal the end of the message using the "<EOF>".
                byte[] message = Encoding.UTF8.GetBytes("Hello from the client.<EOF>");
                // Asynchronously send a message to the server.
                stream.BeginWrite(message, 0, message.Length, 
                    new AsyncCallback(WriteCallback),
                    stream);
            }
            catch (Exception authenticationException)
            {
                e = authenticationException;
                complete = true;
                return;
            }
        }