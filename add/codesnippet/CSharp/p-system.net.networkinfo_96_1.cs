        public static void ShowTimeExceededData()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            Console.WriteLine("  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}",
                statistics.TimeExceededMessagesSent, statistics.TimeExceededMessagesReceived);    
        }