        static void DoConnect(string host, int port)
        {
            // Connect to the specified host.
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);
              
            IPAddress[] IPAddresses = Dns.GetHostAddresses(host);

            Console.WriteLine("Establishing connection to {0}", host);
            t.Connect(IPAddresses, port);

            Console.WriteLine("Connection established");
        }