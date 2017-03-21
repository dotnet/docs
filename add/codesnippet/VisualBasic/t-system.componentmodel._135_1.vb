            Dim ts As New TimeSpan(133333330)
            Dim myTSStr As String = "5000000"
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertTo(ts, GetType(String)))
            Console.WriteLine(TypeDescriptor.GetConverter(ts).ConvertFrom(myTSStr))