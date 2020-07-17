' Visual Basic .NET Document
Option Strict On

Imports System.Collections
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Dim t As New Test()
        t.PopulateFileTable("C:\")
        t.ShowCount()
        t.PrintCreationTime("c:\cas.txt")
    End Sub

    Private Sub ShowCount()
        Console.WriteLine("Hashtable contains {0} files.", h.Count)
        For Each pair As DictionaryEntry In h
            Console.WriteLIne(pair.Key)
        Next
    End Sub
    ' <Snippet10>
    Const initialTableCapacity As Integer = 100
    Dim h As Hashtable

    Public Sub PopulateFileTable(dir As String)
        h = New Hashtable(initialTableCapacity, _
                          StringComparer.OrdinalIgnoreCase)

        For Each filename As String In Directory.GetFiles(dir)
            h.Add(filename, File.GetCreationTime(filename))
        Next
    End Sub

    Public Sub PrintCreationTime(targetFile As String)
        Dim dt As Object = h(targetFile)
        If dt IsNot Nothing Then
            Console.WriteLine("File {0} was created at {1}.", _
               targetFile, _
               CDate(dt))
        Else
            Console.WriteLine("File {0} does not exist.", targetFile)
        End If
    End Sub
    ' </Snippet10>
End Class
