            Dim myUint As Byte = 5 
            Dim myUStr As String = "2"
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertTo(myUint, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myUint).ConvertFrom(myUStr))