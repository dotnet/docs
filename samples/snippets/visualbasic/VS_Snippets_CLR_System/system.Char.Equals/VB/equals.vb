imports Microsoft.VisualBasic
' <snippet20>
imports System

Module EqualsSample

    Sub Main()

        Dim chA As Char
        chA = "A"c
        Dim chB As Char
        chB = "B"c

        Console.WriteLine(chA.Equals("A"c))     ' Output: "True"
        Console.WriteLine("b"c.Equals(chB))     ' Output: "False"

    End Sub

End Module
' </snippet20>
