            double myDoub = 100.55;
            string myDoStr = "4000.425";
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertTo(myDoub, typeof(string))); 
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertFrom(myDoStr));    