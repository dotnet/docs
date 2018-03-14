imports Microsoft.VisualBasic
' <snippet6>
imports System

Module IsLetterOrDigitSample

    Sub Main()

        Dim str As String
        str = "newline:" + vbNewLine

        Console.WriteLine(Char.IsLetterOrDigit("8"c))       ' Output: "True"
        Console.WriteLine(Char.IsLetterOrDigit(str, 8))     ' Output: "False", because it's a NewLine

    End Sub

End Module
' </snippet6>
