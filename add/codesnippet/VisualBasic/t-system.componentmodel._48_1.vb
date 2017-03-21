            Dim myDec As Decimal = 40
            Dim myDStr As String = "20"
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertTo(myDec, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myDec).ConvertFrom(myDStr))