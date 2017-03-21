            bool bVal=true;
            string strA="false";
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertTo(bVal, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertFrom(strA));