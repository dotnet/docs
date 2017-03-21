        public static void GetTcpConnections()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
//            TcpConnectionInformation connections = properties.GetActiveTcpConnections();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            
            foreach (TcpConnectionInformation t in connections)
            {
                Console.Write("Local endpoint: {0} ",t.LocalEndPoint.Address);
                Console.Write("Remote endpoint: {0} ",t.RemoteEndPoint.Address);
                Console.WriteLine("{0}",t.State);
            }
            Console.WriteLine();
        }