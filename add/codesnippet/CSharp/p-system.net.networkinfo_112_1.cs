        public static void DisplayGatewayAddresses()
        {
            Console.WriteLine("Gateways");
            NetworkInterface[] adapters  = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                GatewayIPAddressInformationCollection addresses = adapterProperties.GatewayAddresses;
                if (addresses.Count >0)
                {
                    Console.WriteLine(adapter.Description);
                    foreach (GatewayIPAddressInformation address in addresses)
                    {
                        Console.WriteLine("  Gateway Address ......................... : {0}", 
                            address.Address.ToString());
                    }
                    Console.WriteLine();
                }
            }
        }