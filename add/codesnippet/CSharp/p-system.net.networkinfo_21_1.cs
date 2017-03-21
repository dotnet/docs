        public static void ShowTcpTimeouts()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpStatistics tcpstat = properties.GetTcpIPv4Statistics();
            
            Console.WriteLine("  Minimum Transmission Timeout............. : {0}", 
                tcpstat.MinimumTransmissionTimeout);
            Console.WriteLine("  Maximum Transmission Timeout............. : {0}", 
                tcpstat.MaximumTransmissionTimeout);
            Console.WriteLine("  Maximum connections ............. : {0}", 
                tcpstat.MaximumConnections);
            Console.WriteLine();    
        }