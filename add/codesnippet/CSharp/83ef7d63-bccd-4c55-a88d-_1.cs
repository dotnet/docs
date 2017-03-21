        // Subscribe to a multicast group.
        public static void DoJoinMulticastGroup(UdpClient u, string mcast)
        {
            IPAddress[] multicastAddress = Dns.GetHostAddresses(mcast);
           
            u.JoinMulticastGroup(multicastAddress[0]);
            Console.WriteLine("Joined multicast Address {0}",
                multicastAddress[0]);
        }