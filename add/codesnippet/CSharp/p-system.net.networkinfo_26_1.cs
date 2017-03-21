        public static void ShowTcpConnectionStatistics()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpStatistics tcpstat = properties.GetTcpIPv4Statistics();
                
            Console.WriteLine("  Connection Data:");
            Console.WriteLine("      Current  ............................ : {0}", 
                tcpstat.CurrentConnections);
            Console.WriteLine("      Cumulative .......................... : {0}", 
                tcpstat.CumulativeConnections);
            Console.WriteLine("      Initiated ........................... : {0}", 
                tcpstat.ConnectionsInitiated);
            Console.WriteLine("      Accepted ............................ : {0}", 
                tcpstat.ConnectionsAccepted);
            Console.WriteLine("      Failed Attempts ..................... : {0}", 
                tcpstat.FailedConnectionAttempts);
            Console.WriteLine("      Reset ............................... : {0}", 
                tcpstat.ResetConnections);
            Console.WriteLine("      Errors .............................. : {0}", 
                tcpstat.ErrorsReceived);
            Console.WriteLine();    
        }