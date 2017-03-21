            uint myUInt32 = 967299;
            string myUInt32String = "1345556";
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt32).ConvertTo(myUInt32, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt32).ConvertFrom(myUInt32String));    