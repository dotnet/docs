' <snippet19>
Imports System

Module CompareToSample

    Sub Main()

        Dim chA As Char
        chA = "A"c
        Dim chB As Char
        chB = "B"c

        Console.WriteLine(chA.CompareTo("A"c))  ' Output: "0" (meaning they're equal)
        Console.WriteLine("b"c.CompareTo(chB))  ' Output: "32" (meaning 'b' is 32 greater than 'B')
	Console.WriteLine(chA.CompareTo(chB))	' Output: "-1" (meaning 'A' is less than 'B' by 1)

    End Sub

End Module
' </snippet19>
