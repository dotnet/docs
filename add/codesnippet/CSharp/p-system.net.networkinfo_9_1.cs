        public static void DisplayDhcpServerAddresses()
        {
            Console.WriteLine("DHCP Servers");
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {

                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapterProperties.DhcpServerAddresses;
                if (addresses.Count >0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (IPAddress address in addresses)
                    {
                        Console.WriteLine("  Dhcp Address ............................ : {0}", 
                            address.ToString());
                    }
                    Console.WriteLine();
                }
            }
        }