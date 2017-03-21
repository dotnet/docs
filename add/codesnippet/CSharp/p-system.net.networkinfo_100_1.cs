        public static void ShowIcmpV4EchoData()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            Console.WriteLine("  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}",
                statistics.EchoRequestsSent, statistics.EchoRequestsReceived);
            Console.WriteLine("  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}",
                statistics.EchoRepliesSent, statistics.EchoRepliesReceived);
        }