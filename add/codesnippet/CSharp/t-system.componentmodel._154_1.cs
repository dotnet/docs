            sbyte mySByte=+121;
            string mySByteStr="-100";
            Console.WriteLine(TypeDescriptor.GetConverter(mySByte).ConvertTo(mySByte, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(mySByte).ConvertFrom(mySByteStr));    