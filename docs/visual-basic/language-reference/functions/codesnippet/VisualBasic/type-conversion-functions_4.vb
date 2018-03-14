        Dim someDigits As String
        Dim codePoint As Integer
        Dim thisChar As Char
        someDigits = InputBox("Enter code point of character:")
        codePoint = CInt(someDigits)
        ' The following line of code sets thisChar to the Char value of codePoint.
        thisChar = ChrW(codePoint)