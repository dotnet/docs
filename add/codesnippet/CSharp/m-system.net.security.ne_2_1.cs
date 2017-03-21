        public static void EndReadCallback(IAsyncResult ar)
        {
            // Get the saved data.
            ClientState cState = (ClientState) ar.AsyncState;
            TcpClient clientRequest = cState.Client;
            NegotiateStream authStream = (NegotiateStream) cState.AuthenticatedStream; 
            // Get the buffer that stores the message sent by the client.
            int bytes = -1;
            // Read the client message.
            try
            {
                    bytes = authStream.EndRead(ar);
                    cState.Message.Append(Encoding.UTF8.GetChars(cState.Buffer, 0, bytes));
                    if (bytes != 0)
                    {
                         authStream.BeginRead(cState.Buffer, 0, cState.Buffer.Length, 
                               new AsyncCallback(EndReadCallback), 
                               cState);
                               return;
                 }
            }
            catch (Exception e)
            {
                // A real application should do something
                // useful here, such as logging the failure.
                Console.WriteLine("Client message exception:");
                Console.WriteLine(e);
                cState.Waiter.Set();
                return;
            }
            IIdentity id = authStream.RemoteIdentity;
            Console.WriteLine("{0} says {1}", id.Name, cState.Message.ToString());
            cState.Waiter.Set();
        }