       public static void ShowInboundIPStatistics()
       {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();
            Console.WriteLine("  Inbound Packet Data:");
            Console.WriteLine("      Received ............................ : {0}", 
            ipstat.ReceivedPackets);
            Console.WriteLine("      Forwarded ........................... : {0}", 
            ipstat.ReceivedPacketsForwarded);
            Console.WriteLine("      Delivered ........................... : {0}", 
            ipstat.ReceivedPacketsDelivered);
            Console.WriteLine("      Discarded ........................... : {0}", 
            ipstat.ReceivedPacketsDiscarded);   
       }