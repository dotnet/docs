            byte myUint = 5;
            string myUStr = "2";
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertTo(myUint, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertFrom(myUStr));    