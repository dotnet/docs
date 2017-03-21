        Dim testChar As Char = "e"c
        If Uri.IsHexDigit(testChar) = True Then
            Console.WriteLine("'{0}' is the hexadecimal representation of {1}", testChar, Uri.FromHex(testChar))
        Else
            Console.WriteLine("'{0}' is not a hexadecimal character", testChar)
        End If 
        Dim returnString As String = Uri.HexEscape(testChar)
        Console.WriteLine("The hexadecimal value of '{0}' is {1}", testChar, returnString)