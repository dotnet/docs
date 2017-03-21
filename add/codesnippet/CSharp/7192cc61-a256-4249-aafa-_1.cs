        void ReadCallback(IAsyncResult ar)
        {
            ClientState state = (ClientState) ar.AsyncState;
            SslStream stream = state.stream;
            // Read the  message sent by the client.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            int byteCount = -1;
            try 
            {
                Console.WriteLine("Reading data from the client.");
                byteCount = stream.EndRead(ar);
                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(state.buffer,0, byteCount)];
                decoder.GetChars(state.buffer, 0, byteCount, chars,0);
                state.readData.Append (chars);
                // Check for EOF or an empty message.
                if (state.readData.ToString().IndexOf("<EOF>") == -1 && byteCount != 0)
                {
                    // We are not finished reading.
                    // Asynchronously read more message data from  the client.
                    stream.BeginRead(state.buffer, 0, state.buffer.Length, 
                        new AsyncCallback(ReadCallback),
                        state);
                } 
                else
                {
                    Console.WriteLine("Message from the client: {0}", state.readData.ToString());
                }
                              
                // Encode a test message into a byte array.
                // Signal the end of the message using "<EOF>".
                byte[] message = Encoding.UTF8.GetBytes("Hello from the server.<EOF>");
                // Asynchronously send the message to the client.
                stream.BeginWrite(message, 0, message.Length, 
                    new AsyncCallback(WriteCallback),
                    state);
            }
            catch (Exception readException)
            {
                Console.WriteLine("Read error: {0}", readException.Message);
                state.Close();
                return;
            }
        }