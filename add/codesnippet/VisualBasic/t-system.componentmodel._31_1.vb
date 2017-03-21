            Dim bVal As Boolean = True
            Dim strA As String = "false"
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertTo(bVal, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(bVal).ConvertFrom(strA))