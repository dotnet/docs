        // Thread signal.
        public static ManualResetEvent clientConnected = 
            new ManualResetEvent(false);

        // Accept one client connection asynchronously.
        public static void DoBeginAcceptSocket(TcpListener listener)
        {
            // Set the event to nonsignaled state.
            clientConnected.Reset();

            // Start to listen for connections from a client.
            Console.WriteLine("Waiting for a connection...");

            // Accept the connection. 
            // BeginAcceptSocket() creates the accepted socket.
            listener.BeginAcceptSocket(
                new AsyncCallback(DoAcceptSocketCallback), listener);
            // Wait until a connection is made and processed before 
            // continuing.
            clientConnected.WaitOne();
        }

        // Process the client connection.
        public static void DoAcceptSocketCallback(IAsyncResult ar) 
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener) ar.AsyncState;
            
            // End the operation and display the received data on the
            //console.
            Socket clientSocket = listener.EndAcceptSocket(ar);
    
            // Process the connection here. (Add the client to a 
            // server table, read data, etc.)
            Console.WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            clientConnected.Set();
        }