        public static void DisplayUnicastAddresses()
        {
            Console.WriteLine("Unicast Addresses");
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
                if (uniCast.Count >0)
                {
                    Console.WriteLine(adapter.Description);
                    string lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
                    foreach (UnicastIPAddressInformation uni in uniCast)
                    {
                        DateTime when;
                        
                        Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
                        Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin);
                        Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin);
                        Console.WriteLine("     Duplicate Address Detection .......... : {0}", 
                            uni.DuplicateAddressDetectionState);
                            
                        // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
                        // if en-us is the current culture.
                        
                        // Calculate the date and time at the end of the lifetimes.    
                        when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime);
                        when = when.ToLocalTime();    
                        Console.WriteLine("     Valid Life Time ...................... : {0}", 
                            when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                        );
                        when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressPreferredLifetime);   
                        when = when.ToLocalTime();
                        Console.WriteLine("     Preferred life time .................. : {0}", 
                            when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                        ); 
                        
                        when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime);
                        when = when.ToLocalTime(); 
                        Console.WriteLine("     DHCP Leased Life Time ................ : {0}", 
                            when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                        );
                    }
                    Console.WriteLine();
                }
            }
        }