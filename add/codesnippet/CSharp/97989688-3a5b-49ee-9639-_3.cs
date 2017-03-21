
        static void ReadCallback(IAsyncResult ar)
        {
            // Read the  message sent by the server.
            // The end of the message is signaled using the
            // "<EOF>" marker.
            SslStream stream = (SslStream) ar.AsyncState;
            int byteCount = -1;
            try 
            {
                Console.WriteLine("Reading data from the server.");
                byteCount = stream.EndRead(ar);
                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer,0, byteCount)];
                decoder.GetChars(buffer, 0, byteCount, chars,0);
                readData.Append (chars);
                // Check for EOF or an empty message.
                if (readData.ToString().IndexOf("<EOF>") == -1 && byteCount != 0)
                {
                    // We are not finished reading.
                    // Asynchronously read more message data from  the server.
                    stream.BeginRead(buffer, 0, buffer.Length, 
                        new AsyncCallback(ReadCallback),
                        stream);
                } 
                else
                {
                    Console.WriteLine("Message from the server: {0}", readData.ToString());
                }
            }
            catch (Exception readException)
            {
                e = readException;
                complete = true;
                return;
            }
            complete = true;
        }