        // Synchronous connect using host name (resolved by the 
        // Connect call.)
        public static void Connect3(string host, int port)
        {
            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.Connect(host, port);
            Console.WriteLine("Connection established");
        }		