        // Thread signal.
    public:
        static ManualResetEvent^ TcpClientConnected;

        // Accept one client connection asynchronously.
    public:
        static void DoBeginAcceptTcpClient(TcpListener^ listener)
        {
            // Set the event to nonsignaled state.
            TcpClientConnected->Reset();

            // Start to listen for connections from a client.
            Console::WriteLine("Waiting for a connection...");

            // Accept the connection.
            // BeginAcceptSocket() creates the accepted socket.
            listener->BeginAcceptTcpClient(
                gcnew AsyncCallback(DoAcceptTcpClientCallback),
                listener);

            // Wait until a connection is made and processed before
            // continuing.
            TcpClientConnected->WaitOne();
        }

        // Process the client connection.
    public:
        static void DoAcceptTcpClientCallback(IAsyncResult^ result)
        {
            // Get the listener that handles the client request.
            TcpListener^ listener = (TcpListener^) result->AsyncState;

            // End the operation and display the received data on
            // the console.
            TcpClient^ client = listener->EndAcceptTcpClient(result);

            // Process the connection here. (Add the client to a
            // server table, read data, etc.)
            Console::WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            TcpClientConnected->Set();

        }