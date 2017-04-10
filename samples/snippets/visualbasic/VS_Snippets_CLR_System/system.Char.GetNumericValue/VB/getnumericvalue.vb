' <snippet1>
Module GetNumericValueSample
    Sub Main()
        Dim str As String
        str = "input: 1"

        Console.WriteLine(Char.GetNumericValue("8"c))       ' Output: "8"
        Console.WriteLine(Char.GetNumericValue(str, 7))     ' Output: "1"
    End Sub
End Module
' </snippet1>
