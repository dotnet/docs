        // Asynchronous connect using host name (resolved by the 
        // BeginConnect call.)
        public static void BeginConnect3(string host, int port)
        {
            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            allDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.BeginConnect(host, port, 
                new AsyncCallback(ConnectCallback1), s);

            // wait here until the connect finishes.  The callback 
            // sets allDone.
            allDone.WaitOne();

            Console.WriteLine("Connection established");
        }		