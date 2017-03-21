            Dim myDoub As Double = 100.55
            Dim myDoStr As String = "4000.425"
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertTo(myDoub, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(myDoub).ConvertFrom(myDoStr))