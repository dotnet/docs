' <snippet5>
Imports System

Module IsLetterSample

    Sub Main()

        Dim ch8 As Char
        ch8 = "8"c

        Console.WriteLine(Char.IsLetter(ch8))                   ' Output: "False"
        Console.WriteLine(Char.IsLetter("sample string", 5))    ' Output: "True"

    End Sub

End Module
' </snippet5>
