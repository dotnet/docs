            Char chrA='a';
            string strB="b";
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertTo(chrA, typeof(string)));
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertFrom(strB));