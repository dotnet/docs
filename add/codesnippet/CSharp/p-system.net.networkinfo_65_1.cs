        public static void ShowInterfaceSpeedAndQueue()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                IPv4InterfaceStatistics stats = adapter.GetIPv4Statistics();
                 Console.WriteLine(adapter.Description);
                Console.WriteLine("     Speed .................................: {0}", 
                    adapter.Speed);
                Console.WriteLine("     Output queue length....................: {0}", 
                    stats.OutputQueueLength);
            }
        }