        public static void ShowAddressMaskData()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            Console.WriteLine("  Address Mask Requests ............... Sent: {0,-10}   Received: {1,-10}",
                statistics.AddressMaskRequestsSent, statistics.AddressMaskRequestsReceived);    
            Console.WriteLine("  Address Mask Replies ................ Sent: {0,-10}   Received: {1,-10}",
                statistics.AddressMaskRepliesSent, statistics.AddressMaskRepliesReceived);     
                 
        }