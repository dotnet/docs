        // Thread signal.
    public:
        static ManualResetEvent^ ClientConnected;

        // Accept one client connection asynchronously.
    public:
        static void DoBeginAcceptSocket(TcpListener^ listener)
        {
            // Set the event to nonsignaled state.
            ClientConnected->Reset();

            // Start to listen for connections from a client.
            Console::WriteLine("Waiting for a connection...");

            // Accept the connection.
            // BeginAcceptSocket() creates the accepted socket.
            listener->BeginAcceptSocket(
                gcnew AsyncCallback(DoAcceptSocketCallback), listener);
            // Wait until a connection is made and processed before
            // continuing.
            ClientConnected->WaitOne();
        }

        // Process the client connection.
    public:
        static void DoAcceptSocketCallback(IAsyncResult^ result)
        {
            // Get the listener that handles the client request.
            TcpListener^ listener = (TcpListener^) result->AsyncState;

            // End the operation and display the received data on the
            //console.
            Socket^ clientSocket = listener->EndAcceptSocket(result);

            // Process the connection here. (Add the client to a
            // server table, read data, etc.)
            Console::WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            ClientConnected->Set();
        }