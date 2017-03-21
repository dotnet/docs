        foreach(Color c in TypeDescriptor.GetConverter(typeof(Color)).GetStandardValues()) {
            Console.WriteLine(TypeDescriptor.GetConverter(c).ConvertToString(c));
         }