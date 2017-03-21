        public static void DisplayAnycastAddresses()
        {
            int count = 0;
            
            Console.WriteLine("Anycast Addresses");
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressInformationCollection anyCast = adapterProperties.AnycastAddresses;
                if (anyCast.Count >0)
                {
                    
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddressInformation any in anyCast)
                    {
                        Console.WriteLine("  Anycast Address .......................... : {0} {1} {2}", 
                            any.Address,
                            any.IsTransient ? "Transient" : "", 
                            any.IsDnsEligible ? "DNS Eligible" : ""
                        );
                        count++;
                    }
                    Console.WriteLine();
                }
            }
            if (count == 0)
            {
                Console.WriteLine("  No anycast addressses were found.");
                Console.WriteLine();
            }
        }