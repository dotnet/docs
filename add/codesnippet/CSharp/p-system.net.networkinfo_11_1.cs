        public static void DisplayMulticastAddresses()
        {
            int count = 0;
            
            Console.WriteLine("Multicast Addresses");
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                MulticastIPAddressInformationCollection multiCast = adapterProperties.MulticastAddresses;
                if (multiCast.Count > 0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddressInformation multi in multiCast)
                    {
                        Console.WriteLine("  Multicast Address ....................... : {0} {1} {2}", 
                            multi.Address,
                            multi.IsTransient ? "Transient" : "", 
                            multi.IsDnsEligible ? "DNS Eligible" : ""
                        );
                        count++;
                    }
                    Console.WriteLine();
                }
            }
            if (count == 0)
            {
                Console.WriteLine("  No multicast addressses were found.");
                Console.WriteLine();
            }
        }