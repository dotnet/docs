        // The following method is called when the write operation completes.
        public static void EndWriteCallback (IAsyncResult ar)
        {
            Console.WriteLine("Client ending write operation...");
            NegotiateStream authStream = (NegotiateStream) ar.AsyncState;

            // End the asynchronous operation.
            authStream.EndWrite(ar);
        }