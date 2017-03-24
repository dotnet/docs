        Dim aString As String = "Example String"
        Dim anon2 = New With {Key aString.First()}
        ' The variable anon2 has one property, First.
        Console.WriteLine(anon2.First)