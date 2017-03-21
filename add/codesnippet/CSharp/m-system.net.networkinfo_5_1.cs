        public static void ShowIPStatistics(NetworkInterfaceComponent version)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPGlobalStatistics ipstat = null;
            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                     ipstat = properties.GetIPv4GlobalStatistics();
                   Console.WriteLine("{0}IPv4 Statistics ",Environment.NewLine);
                    break;
                case NetworkInterfaceComponent.IPv6:
                    ipstat = properties.GetIPv4GlobalStatistics();
                    Console.WriteLine("{0}IPv6 Statistics ",Environment.NewLine);
                    break;
                default:
                    throw new ArgumentException("version");
                //    break;
            }
            Console.WriteLine("  Forwarding enabled ...................... : {0}", 
                ipstat.ForwardingEnabled);
            Console.WriteLine("  Interfaces .............................. : {0}", 
                ipstat.NumberOfInterfaces);
            Console.WriteLine("  IP addresses ............................ : {0}", 
                ipstat.NumberOfIPAddresses);
            Console.WriteLine("  Routes .................................. : {0}", 
                ipstat.NumberOfRoutes);
            Console.WriteLine("  Default TTL ............................. : {0}", 
                ipstat.DefaultTtl);
            Console.WriteLine("");    
            Console.WriteLine("  Inbound Packet Data:");
            Console.WriteLine("      Received ............................ : {0}", 
                ipstat.ReceivedPackets);
            Console.WriteLine("      Forwarded ........................... : {0}", 
                ipstat.ReceivedPacketsForwarded);
            Console.WriteLine("      Delivered ........................... : {0}", 
                ipstat.ReceivedPacketsDelivered);
            Console.WriteLine("      Discarded ........................... : {0}", 
                ipstat.ReceivedPacketsDiscarded);
            Console.WriteLine("      Header Errors ....................... : {0}", 
                ipstat.ReceivedPacketsWithHeadersErrors);
            Console.WriteLine("      Address Errors ...................... : {0}", 
                ipstat.ReceivedPacketsWithAddressErrors);
            Console.WriteLine("      Unknown Protocol Errors ............. : {0}", 
                ipstat.ReceivedPacketsWithUnknownProtocol);
            Console.WriteLine("");    
            Console.WriteLine("  Outbound Packet Data:");
            Console.WriteLine("      Requested ........................... : {0}", 
                 ipstat.OutputPacketRequests);
            Console.WriteLine("      Discarded ........................... : {0}", 
                ipstat.OutputPacketsDiscarded);
            Console.WriteLine("      No Routing Discards ................. : {0}", 
                ipstat.OutputPacketsWithNoRoute);
            Console.WriteLine("      Routing Entry Discards .............. : {0}", 
                ipstat.OutputPacketRoutingDiscards);
            Console.WriteLine("");    
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
            Console.WriteLine("");
        }