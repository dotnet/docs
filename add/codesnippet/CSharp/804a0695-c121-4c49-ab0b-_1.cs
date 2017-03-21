        public static void ShowIcmpV4UnreachableData()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            Console.WriteLine("  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}",
                statistics.DestinationUnreachableMessagesSent, 
                statistics.DestinationUnreachableMessagesReceived);
        }