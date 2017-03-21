        void WriteCallback(IAsyncResult ar)
        {
            ClientState state = (ClientState) ar.AsyncState;
            SslStream stream = state.stream;
            try 
            {
                Console.WriteLine("Writing data to the client.");
                stream.EndWrite(ar);
            }
            catch (Exception writeException)
            {
                Console.WriteLine("Write error: {0}", 
                    writeException.Message);
                state.Close();
                return;
            }
            Console.WriteLine("Finished with client.");
            state.Close();
        }