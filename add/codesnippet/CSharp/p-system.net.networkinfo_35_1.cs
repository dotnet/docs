        public static void ShowParameterData()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IcmpV4Statistics statistics = properties.GetIcmpV4Statistics();
            Console.WriteLine("  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}",
                statistics.ParameterProblemsSent, statistics.ParameterProblemsReceived);        
                 
        }