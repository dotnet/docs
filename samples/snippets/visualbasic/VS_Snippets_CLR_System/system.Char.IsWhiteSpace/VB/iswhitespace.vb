imports Microsoft.VisualBasic
' <snippet14>
imports System

Module IsWhiteSpaceSample

    Sub Main()

        Dim str As String
        str = "black matter"

        Console.WriteLine(Char.IsWhiteSpace("A"c))      ' Output: "False"
        Console.WriteLine(Char.IsWhiteSpace(str, 5))    ' Output: "True"

    End Sub

End Module
' </snippet14>
