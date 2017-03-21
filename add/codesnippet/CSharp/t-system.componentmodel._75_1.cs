            ushort myUInt16 = 10000;
            string myUInt16String = "20000";
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt16).ConvertTo(myUInt16, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUInt16).ConvertFrom(myUInt16String));    