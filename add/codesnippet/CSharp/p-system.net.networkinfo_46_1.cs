        public static void ShowUdpStatistics(NetworkInterfaceComponent version)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            UdpStatistics udpStat = null;
            
            switch (version)
            {
                case NetworkInterfaceComponent.IPv4:
                    udpStat = properties.GetUdpIPv4Statistics();
                    Console.WriteLine("UDP IPv4 Statistics");
                    break;
                case NetworkInterfaceComponent.IPv6:
                    udpStat = properties.GetUdpIPv6Statistics();
                    Console.WriteLine("UDP IPv6 Statistics");
                    break;
                default:
                    throw new ArgumentException("version");
                //    break;
            }
            Console.WriteLine("  Datagrams Received ...................... : {0}", 
                udpStat.DatagramsReceived);
            Console.WriteLine("  Datagrams Sent .......................... : {0}", 
                udpStat.DatagramsSent);
            Console.WriteLine("  Incoming Datagrams Discarded ............ : {0}", 
                udpStat.IncomingDatagramsDiscarded);
            Console.WriteLine("  Incoming Datagrams With Errors .......... : {0}", 
                udpStat.IncomingDatagramsWithErrors);
            Console.WriteLine("  UDP Listeners ........................... : {0}", 
                udpStat.UdpListeners);
            Console.WriteLine("");
        }