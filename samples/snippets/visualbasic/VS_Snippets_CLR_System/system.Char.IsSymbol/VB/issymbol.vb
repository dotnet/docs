' <snippet12>
Imports System

Module IsSymbolSample

    Sub Main()

        Dim str As String
        str = "non-symbolic characters"

        Console.WriteLine(Char.IsSymbol("+"c))      ' Output: "True"
        Console.WriteLine(Char.IsSymbol(str, 8))    ' Output: "False"

    End Sub

End Module
' </snippet12>
