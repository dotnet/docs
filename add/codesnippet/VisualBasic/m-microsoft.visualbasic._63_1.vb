        Dim aString As String = "Wow! What a string!"
        Dim aObject As New Object
        Dim TestString As String
        aObject = "This is a String contained within an Object"
        ' Returns "PPPPP"
        TestString = StrDup(5, "P")
        ' Returns "WWWWWWWWWW"
        TestString = StrDup(10, aString)
        ' Returns "TTTTTT"
        TestString = CStr(StrDup(6, aObject))