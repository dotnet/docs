'<Snippet1> 
' For Directory.GetFiles and Directory.GetDirectories
'<Snippet2> 
' For File.Exists, Directory.Exists 

Imports System
Imports System.IO
Imports System.Collections

Public Class RecursiveFileProcessor

    Public Overloads Shared Sub Main(ByVal args() As String)
        Dim path As String
        For Each path In args
            If File.Exists(path) Then
                ' This path is a file.
                ProcessFile(path)
            Else
                If Directory.Exists(path) Then
                    ' This path is a directory.
                    ProcessDirectory(path)
                Else
                    Console.WriteLine("{0} is not a valid file or directory.", path)
                End If
            End If
        Next path
    End Sub 'Main


    ' Process all files in the directory passed in, recurse on any directories 
    ' that are found, and process the files they contain.
    Public Shared Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        ' Process the list of files found in the directory.
        Dim fileName As String
        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        ' Recurse into subdirectories of this directory.
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)
        Next subdirectory

    End Sub 'ProcessDirectory

    ' Insert logic for processing found files here.
    Public Shared Sub ProcessFile(ByVal path As String)
        Console.WriteLine("Processed file '{0}'.", path)
    End Sub 'ProcessFile
End Class 'RecursiveFileProcessor
'</Snippet2>
'</Snippet1>