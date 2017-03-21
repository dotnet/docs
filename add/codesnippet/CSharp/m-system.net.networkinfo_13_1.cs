            public static PhysicalAddress[] StoreNetworkInterfaceAddresses()
        {
            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            if (nics == null || nics.Length < 1)
            {
                Console.WriteLine("  No network interfaces found.");
                return null;
            }
                             
            PhysicalAddress[] addresses = new PhysicalAddress[nics.Length];
            int i = 0;
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                PhysicalAddress address = adapter.GetPhysicalAddress();
                byte[] bytes = address.GetAddressBytes();
                PhysicalAddress newAddress =  new PhysicalAddress(bytes);
                addresses[i++]=newAddress;
             }
            return addresses;
        }