        public static void ShowRedirectsData()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            Console.WriteLine("  Redirects ........................... Sent: {0,-10}   Received: {1,-10}",
                statistics.RedirectsSent, statistics.RedirectsReceived);  
        }