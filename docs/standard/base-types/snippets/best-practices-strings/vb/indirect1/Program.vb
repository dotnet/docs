Imports System.IO

Module Program
    Const InitialCapacity As Integer = 100

    Private ReadOnly s_creationTimeByFile As New Hashtable(InitialCapacity, StringComparer.OrdinalIgnoreCase)
    Private ReadOnly s_directoryToProcess As String = Directory.GetCurrentDirectory()

    Sub Main()
        ' Fill the hash table
        PopulateFileTable(s_directoryToProcess)

        ' Get some of the files and try to find them with upper cased names
        For Each File As String In Directory.GetFiles(s_directoryToProcess)
            PrintCreationTime(File.ToUpper())
        Next
    End Sub

    Sub PopulateFileTable(directoryPath As String)
        For Each file As String In Directory.GetFiles(directoryPath)
            s_creationTimeByFile.Add(file, IO.File.GetCreationTime(file))
        Next
    End Sub

    Sub PrintCreationTime(targetFile As String)
        Dim dt As Object = s_creationTimeByFile(targetFile)

        If TypeOf dt Is Date Then
            Console.WriteLine($"File {targetFile} was created at time {DirectCast(dt, Date)}.")
        Else
            Console.WriteLine($"File {targetFile} does not exist.")
        End If
    End Sub
End Module
