        public static void ParseTest()
        {
            PhysicalAddress address = PhysicalAddress.Parse("AC1EBA22");
            Console.WriteLine("Address parsed as {0}", address.ToString());
            PhysicalAddress address2 = PhysicalAddress.Parse("ac1eba22");
            Console.WriteLine("Address2 parsed as {0}", address2.ToString());
            bool test = address.Equals(address2);
            Console.WriteLine("Equal? {0}", test);
        }