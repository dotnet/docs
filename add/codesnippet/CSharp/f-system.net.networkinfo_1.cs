        public static PhysicalAddress StrictParseAddress(string address)
        {
            PhysicalAddress newAddress = PhysicalAddress.Parse(address);
            if (PhysicalAddress.None.Equals(newAddress))
                return null;

            return newAddress;
        }