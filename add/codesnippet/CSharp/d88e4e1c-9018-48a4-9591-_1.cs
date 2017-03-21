        // Connect asynchronously to the specifed host.
        public static void DoBeginConnect3(string host, int port)
        {
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);

            connectDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            t.BeginConnect(host, port, 
                new AsyncCallback(ConnectCallback), t);

            // Wait here until the callback processes the connection.
            connectDone.WaitOne();

            Console.WriteLine("Connection established");
        }