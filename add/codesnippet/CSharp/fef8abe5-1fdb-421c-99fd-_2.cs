        // Asynchronous connect using the host name, resolved via 
        // IPAddress
        public static void BeginConnect1(string host, int port)
        {

            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            allDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.BeginConnect(IPs[0], port, 
                new AsyncCallback(ConnectCallback1), s);

            // wait here until the connect finishes.  
            // The callback sets allDone.
            allDone.WaitOne();

            Console.WriteLine("Connection established");

        }		