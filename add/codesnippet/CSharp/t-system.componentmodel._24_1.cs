            Single s=3.402823E+10F;
            string mySStr="3.402823E+10";
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertTo(s, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertFrom(mySStr));    