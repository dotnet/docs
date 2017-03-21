        Dim c As Color
        For Each c In  TypeDescriptor.GetConverter(GetType(Color)).GetStandardValues()
            Console.WriteLine(TypeDescriptor.GetConverter(c).ConvertToString(c))
        Next c