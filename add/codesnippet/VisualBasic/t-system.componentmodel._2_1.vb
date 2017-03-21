            Dim myInt64 As Long = -123456789123
            Dim myInt64String As String = "+184467440737095551"
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertTo(myInt64, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myInt64).ConvertFrom(myInt64String))