            Dim myInt32 As Integer = -967299
            Dim myInt32String As String = "+1345556"
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertTo(myInt32, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myInt32).ConvertFrom(myInt32String))