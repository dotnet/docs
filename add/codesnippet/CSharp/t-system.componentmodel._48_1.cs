            decimal myDec = 40;
            string myDStr = "20";
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertTo(myDec, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertFrom(myDStr));    