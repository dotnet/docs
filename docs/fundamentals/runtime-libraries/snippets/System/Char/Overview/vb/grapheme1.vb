' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.IO

Module Example2
    Public Sub Main()
        Dim sw As New StreamWriter("chars1.txt")
        Dim chars() As Char = {ChrW(&H61), ChrW(&H308)}
        Dim strng As New String(chars)
        sw.WriteLine(strng)
        sw.Close()
    End Sub
End Module
' The example produces the following output:
'       ä
' </Snippet1>
