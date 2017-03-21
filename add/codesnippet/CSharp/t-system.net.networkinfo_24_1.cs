        public static void DisplayDnsAddresses()
        {
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                if (dnsServers.Count > 0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddress dns in dnsServers)
                    {
                        Console.WriteLine("  DNS Servers ............................. : {0}", 
                            dns.ToString());
                    }
                    Console.WriteLine();
                }
            }
        }