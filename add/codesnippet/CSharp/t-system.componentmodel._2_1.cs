            long myInt64 = -123456789123;
            string myInt64String = "+184467440737095551";
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertTo(myInt64, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertFrom(myInt64String));    