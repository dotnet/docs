            Dim myInt16 As Short = -10000
            Dim myInt16String As String = "+20000"
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertTo(myInt16, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myInt16).ConvertFrom(myInt16String))