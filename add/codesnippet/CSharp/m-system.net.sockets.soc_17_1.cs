        // Synchronous connect using IPAddress to resolve the 
        // host name.
        public static void Connect1(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
 
            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.Connect(IPs[0], port);
            Console.WriteLine("Connection established");
        }		