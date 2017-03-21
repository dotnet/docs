        public static void CountTcpConnections()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            int establishedConnections = 0;
            
            foreach (TcpConnectionInformation t in connections)
            {
                if (t.State == TcpState.Established)
                {
                     establishedConnections++;
                }
                Console.Write("Local endpoint: {0} ",t.LocalEndPoint.Address);
                Console.WriteLine("Remote endpoint: {0} ",t.RemoteEndPoint.Address);
               
            }
             Console.WriteLine("There are {0} established TCP connections.",
                establishedConnections);
        }