' <snippet1>
Imports System

Module GetUnicodeCategorySample

    Sub Main()

        Dim ch2 As Char
        ch2 = "2"c
        Dim str As String
        str = "Upper Case"

        Console.WriteLine(Char.GetUnicodeCategory("a"c))    ' Output: "1" (LowercaseLetter)
        Console.WriteLine(Char.GetUnicodeCategory(ch2))     ' Output: "8" (DecimalDigitNumber)
        Console.WriteLine(Char.GetUnicodeCategory(str, 6))  ' Output: "0" (UppercaseLetter)

    End Sub

End Module
' </snippet1>