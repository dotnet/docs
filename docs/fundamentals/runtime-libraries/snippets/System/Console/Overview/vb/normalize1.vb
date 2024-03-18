' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Module Example3
    Public Sub Main()
        Dim chars() As Char = {ChrW(&H61), ChrW(&H308)}

        Dim combining As String = New String(chars)
        Console.WriteLine(combining)

        combining = combining.Normalize()
        Console.WriteLine(combining)
    End Sub
End Module
' The example displays the following output:
'       a"
'       ä
' </Snippet5>
