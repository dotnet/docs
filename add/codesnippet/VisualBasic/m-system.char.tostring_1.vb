Imports System

Module ToStringSample

    Sub Main()

        Dim ch As Char
        ch = "a"c
        Console.WriteLine(ch.ToString())        ' Output: "a"

        Console.WriteLine(Char.ToString("b"c))  ' Output: "b"

    End Sub

End Module