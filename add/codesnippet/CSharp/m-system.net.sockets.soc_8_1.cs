        // Synchronous connect using Dns.GetHostAddresses to 
        // resolve the host name.
        public static void Connect2(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.Connect(IPs, port);
            Console.WriteLine("Connection established");
        }		