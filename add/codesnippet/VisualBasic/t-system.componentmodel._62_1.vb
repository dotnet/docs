Dim strM As String
strM = "1,2,3,4"
            Dim m As New System.Drawing.Printing.Margins(1, 2, 3, 4)
Console.WriteLine(TypeDescriptor.GetConverter(strM).CanConvertTo(GetType(System.Drawing.Printing.Margins)))
Console.WriteLine(TypeDescriptor.GetConverter(m).ConvertToString(m))