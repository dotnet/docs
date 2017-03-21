            Dim dt As New DateTime(1990, 5, 6)
            Console.WriteLine(TypeDescriptor.GetConverter(dt).ConvertTo(dt, GetType(String)))
            Dim myStr As String = "1991-10-10"
            Console.WriteLine(TypeDescriptor.GetConverter(dt).ConvertFrom(myStr))