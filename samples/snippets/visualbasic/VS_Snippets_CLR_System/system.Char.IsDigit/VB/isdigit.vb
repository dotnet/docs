' <snippet4>
Imports System

Module IsDigitSample

    Sub Main()

        Dim ch8 As Char
        ch8 = "8"c

        Console.WriteLine(Char.IsDigit(ch8))                    ' Output: "True"
        Console.WriteLine(Char.IsDigit("sample string", 6))     ' Output: "False"

    End Sub

End Module
' </snippet4>
