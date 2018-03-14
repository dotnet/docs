' <snippet8>
Module IsNumberSample
    Sub Main()
        Dim str As String
        str = "non-numeric"

        Console.WriteLine(Char.IsNumber("8"c))      ' Output: "True"
        Console.WriteLine(Char.IsNumber(str, 3))    ' Output: "False"
    End Sub
End Module
' </snippet8>
