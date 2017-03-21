        public static void DoGetHostEntry(string hostname)
        {
            IPHostEntry host;

            host = Dns.GetHostEntry(hostname);

            Console.WriteLine("GetHostEntry({0}) returns:", hostname);

            foreach (IPAddress ip in host.AddressList)
            {
                Console.WriteLine("    {0}", ip);
            }
        }