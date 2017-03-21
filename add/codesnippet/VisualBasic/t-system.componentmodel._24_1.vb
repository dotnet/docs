            Dim s As [Single] = 3.402823E+10F
            Dim mySStr As String = "3.402823E+10"
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertTo(s, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(s).ConvertFrom(mySStr))