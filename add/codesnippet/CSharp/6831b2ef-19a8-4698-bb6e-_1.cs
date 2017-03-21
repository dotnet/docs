        public static void DoBeginConnect1(string host, int port)
        {
            // Connect asynchronously to the specifed host.
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);
//            IPAddress remoteHost = new IPAddress(host);
            IPAddress[] remoteHost = Dns.GetHostAddresses(host);

            connectDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                remoteHost[0]);
            t.BeginConnect(remoteHost[0], port, 
                new AsyncCallback(ConnectCallback), t);

            // Wait here until the callback processes the connection.
            connectDone.WaitOne();

            Console.WriteLine("Connection established");
        }