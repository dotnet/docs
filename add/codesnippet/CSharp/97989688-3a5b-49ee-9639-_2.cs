        static void WriteCallback(IAsyncResult ar)
        {
            SslStream stream = (SslStream) ar.AsyncState;
            try 
            {
                Console.WriteLine("Writing data to the server.");
                stream.EndWrite(ar);
                // Asynchronously read a message from the server.
                stream.BeginRead(buffer, 0, buffer.Length, 
                    new AsyncCallback(ReadCallback),
                    stream);
            }
            catch (Exception writeException)
            {
                e = writeException;
                complete = true;
                return;
            }
        }