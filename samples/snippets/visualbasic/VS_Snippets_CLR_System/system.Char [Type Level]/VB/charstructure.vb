imports Microsoft.VisualBasic
' <snippet23>
imports System

Module CharStructure

    Public Sub Main()

        Dim chA As Char
        chA = "A"c
        Dim ch1 As Char
        ch1 = "1"c
        Dim str As String
        str = "test string"

        Console.WriteLine(chA.CompareTo("B"c))          ' Output: "-1" (meaning 'A' is 1 less than 'B')
        Console.WriteLine(chA.Equals("A"c))             ' Output: "True"
        Console.WriteLine(Char.GetNumericValue(ch1))    ' Output: "1"
        Console.WriteLine(Char.IsControl(Chr(9)))       ' Output: "True"
        Console.WriteLine(Char.IsDigit(ch1))            ' Output: "True"
        Console.WriteLine(Char.IsLetter(","c))          ' Output: "False"
        Console.WriteLine(Char.IsLower("u"c))           ' Output: "True"
        Console.WriteLine(Char.IsNumber(ch1))           ' Output: "True"
        Console.WriteLine(Char.IsPunctuation("."c))     ' Output: "True"
        Console.WriteLine(Char.IsSeparator(str, 4))     ' Output: "True"
        Console.WriteLine(Char.IsSymbol("+"c))          ' Output: "True"
        Console.WriteLine(Char.IsWhiteSpace(str, 4))    ' Output: "True"
        Console.WriteLine(Char.Parse("S"))              ' Output: "S"
        Console.WriteLine(Char.ToLower("M"c))           ' Output: "m"
        Console.WriteLine("x"c.ToString())              ' Output: "x"

    End Sub

End Module
' </snippet23>
