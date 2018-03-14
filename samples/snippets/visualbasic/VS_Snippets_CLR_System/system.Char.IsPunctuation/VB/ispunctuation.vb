' <snippet9>
Imports System

Module IsPunctuationSample

    Sub Main()

        Dim ch As Char
        ch = "."c

        Console.WriteLine(Char.IsPunctuation(ch))                   ' Output: "True"
        Console.WriteLine(Char.IsPunctuation("no punctuation", 3))  ' Output: "False"

    End Sub

End Module
' </snippet9>
