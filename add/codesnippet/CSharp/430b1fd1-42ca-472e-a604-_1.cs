        public static void ShowIcmpV6UnreachableData ()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV6Statistics statistics = properties.GetIcmpV6Statistics();
            Console.WriteLine ("  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", 
                statistics.DestinationUnreachableMessagesSent, statistics.DestinationUnreachableMessagesReceived);
        }
