        Dim testString As String = "%75"
        Dim index As Integer = 0
        If Uri.IsHexEncoding(testString, index) Then
            Console.WriteLine("The character is {0}", Uri.HexUnescape(testString, index))
        Else
            Console.WriteLine("The character is not hexadecimal encoded")
        End If