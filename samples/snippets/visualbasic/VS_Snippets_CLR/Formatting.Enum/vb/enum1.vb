' Visual Basic .NET Document
Option Strict On

Imports System.IO

' <Snippet5>
Public Enum Color
    Red = 1
    Blue = 2
    Green = 3
End Enum
' </Snippet5>

Module modMain
    Public Sub Main()
        ShowGSpecifier()
        ShowFSpecifier()
        ShowDSpecifier()
        ShowXSpecifier()
        ShowExample()
    End Sub

    Private Sub ShowGSpecifier()
        Console.WriteLine("G Specifier:")
        ' <Snippet1>
        Console.WriteLine((CType(7, DayOfWeek)).ToString("G"))    ' 7
        Console.WriteLine(ConsoleColor.Red.ToString("G"))         ' Red
        Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                           FileAttributes.Archive
        Console.WriteLine(attributes.ToString("G"))               ' Hidden, Archive
        ' </Snippet1>
        Console.WriteLine()
    End Sub

    Private Sub ShowFSpecifier()
        Console.WriteLine("F Specifier:")
        ' <Snippet2>
        Console.WriteLine((CType(7, DayOfWeek)).ToString("F"))    ' Monday, Saturday
        Console.WriteLine(ConsoleColor.Blue.ToString("F"))        ' Blue
        Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                           FileAttributes.Archive
        Console.WriteLine(attributes.ToString("F"))               ' Hidden, Archive
        ' </Snippet2>
        Console.WriteLine()
    End Sub

    Private Sub ShowDSpecifier()
        Console.WriteLine("D Specifier:")
        ' <Snippet3>
        Console.WriteLine((CType(7, DayOfWeek)).ToString("D"))     ' 7
        Console.WriteLine(ConsoleColor.Cyan.ToString("D"))         ' 11
        Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                           FileAttributes.Archive
        Console.WriteLine(attributes.ToString("D"))                ' 34
        ' </Snippet3>
        Console.WriteLine()
    End Sub

    Private Sub ShowXSpecifier()
        Console.WriteLine("X Specifier:")
        ' <Snippet4>
        Console.WriteLine((CType(7, DayOfWeek)).ToString("X"))    ' 00000007
        Console.WriteLine(ConsoleColor.Cyan.ToString("X"))        ' 0000000B
        Dim attributes As FileAttributes = FileAttributes.Hidden Or _
                                           FileAttributes.Archive
        Console.WriteLine(attributes.ToString("X"))               ' 00000022
        ' </Snippet4>
        Console.WriteLine()
    End Sub

    Private Sub ShowExample()
        Console.WriteLine("Example:")
        ' <Snippet6>
        Dim myColor As Color = Color.Green
        ' </Snippet6>

        ' <Snippet7>
        Console.WriteLine("The value of myColor is {0}.", _
                          myColor.ToString("G"))
        Console.WriteLine("The value of myColor is {0}.", _
                          myColor.ToString("F"))
        Console.WriteLine("The value of myColor is {0}.", _
                          myColor.ToString("D"))
        Console.WriteLine("The value of myColor is 0x{0}.", _
                          myColor.ToString("X"))
        ' The example displays the following output to the console:
        '       The value of myColor is Green.
        '       The value of myColor is Green.
        '       The value of myColor is 3.
        '       The value of myColor is 0x00000003.      
        ' </Snippet7>
    End Sub
End Module

