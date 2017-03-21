        public static void ShowFragmentationStatistics()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();
            Console.WriteLine("  Reassembly Data:");
            Console.WriteLine("      Reassembly Timeout .................. : {0}", 
                ipstat.PacketReassemblyTimeout);
            Console.WriteLine("      Reassemblies Required ............... : {0}", 
                ipstat.PacketReassembliesRequired);
            Console.WriteLine("      Packets Reassembled ................. : {0}", 
                ipstat.PacketsReassembled);
            Console.WriteLine("      Packets Fragmented .................. : {0}", 
                ipstat.PacketsFragmented);
            Console.WriteLine("      Fragment Failures ................... : {0}", 
                ipstat.PacketFragmentFailures);
        }