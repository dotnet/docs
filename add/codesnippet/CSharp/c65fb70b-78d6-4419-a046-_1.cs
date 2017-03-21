        // Connect asynchronously to the specifed host.
        public static void DoBeginConnect2(string host, int port)
        {
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);
            IPAddress[] remoteHost = Dns.GetHostAddresses(host);

            connectDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", host);
            t.BeginConnect(remoteHost, port, 
                new AsyncCallback(ConnectCallback), t);

            // Wait here until the callback processes the connection.
            connectDone.WaitOne();

            Console.WriteLine("Connection established");
        }