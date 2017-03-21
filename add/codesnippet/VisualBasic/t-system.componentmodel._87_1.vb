            Dim chrA As [Char] = "a"c
            Dim strB As String = "b"
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertTo(chrA, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(chrA).ConvertFrom(strB))