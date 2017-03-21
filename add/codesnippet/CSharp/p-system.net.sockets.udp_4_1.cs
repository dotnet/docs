        public static void GetSetExclusiveAddressUse(UdpClient u)
        {
            // Don't allow another client to bind to this port.
            u.ExclusiveAddressUse = true;
            Console.WriteLine("ExclusiveAddressUse value is {0}",
                u.ExclusiveAddressUse);
        }