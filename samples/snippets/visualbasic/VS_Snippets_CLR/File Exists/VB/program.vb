Imports System.IO
Module Module1

    Sub Main()
' <Snippet1>
Dim curFile As String = "c:\temp\test.txt"
Console.WriteLine(If(File.Exists(curFile), "File exists.", "File does not exist."))
' </Snippet1>
    End Sub
End Module
