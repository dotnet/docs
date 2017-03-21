            ulong myUInt64 = 123456789123;
            string myUInt64String = "184467440737095551";
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt64).ConvertTo(myUInt64, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt64).ConvertFrom(myUInt64String));    