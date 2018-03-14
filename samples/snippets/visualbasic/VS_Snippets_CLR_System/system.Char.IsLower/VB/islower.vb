' <snippet7>
Imports System

Module IsLowerSample

    Sub Main()

        Dim ch As Char
        ch = "a"c

        Console.WriteLine(Char.IsLower(ch))                 ' Output: "True"
        Console.WriteLine(Char.IsLower("upperCase", 5))     ' Output: "False"

    End Sub

End Module
' </snippet7>
