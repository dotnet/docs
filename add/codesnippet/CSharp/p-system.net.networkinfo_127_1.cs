        public static void ShowInterfaceSummary()
        {
            
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {                
                Console.WriteLine ("Name: {0}", adapter.Name);
                Console.WriteLine(adapter.Description);
                Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length,'='));
                Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                Console.WriteLine("  Operational status ...................... : {0}", 
                    adapter.OperationalStatus);
                string versions ="";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                     versions = "IPv4";
                 }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                     }
                    versions += "IPv6";
                }
                Console.WriteLine("  IP version .............................. : {0}", versions);
                Console.WriteLine();
            }
            Console.WriteLine();
        }