            int myInt32 = -967299;
            string myInt32String = "+1345556";
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertTo(myInt32, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertFrom(myInt32String));    