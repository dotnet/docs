            short myInt16 = -10000;
            string myInt16String = "+20000";
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertTo(myInt16, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertFrom(myInt16String));    