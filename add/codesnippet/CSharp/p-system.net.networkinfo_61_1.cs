        public static void ShowIcmpV6EchoData ()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV6Statistics statistics = properties.GetIcmpV6Statistics();
            Console.WriteLine ("  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", 
                statistics.EchoRequestsSent, statistics.EchoRequestsReceived);
            Console.WriteLine ("  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", 
                statistics.EchoRepliesSent, statistics.EchoRepliesReceived);
        }
