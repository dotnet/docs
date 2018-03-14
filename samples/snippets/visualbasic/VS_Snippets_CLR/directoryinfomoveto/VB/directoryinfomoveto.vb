'<snippet1>
Imports System
Imports System.IO

Public Class MoveToTest

    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("TempDir")
        ' Create the directory only if it does not already exist.
        If di.Exists = False Then
            di.Create()
        End If

        ' Create a subdirectory in the directory just created.
        Dim dis As DirectoryInfo = di.CreateSubdirectory("SubDir")
        If Directory.Exists("NewTempDir") = False Then
            ' Move the main directory. Note that the contents move with the directory.
            di.MoveTo("NewTempDir")
        End If
        Try
            ' Attempt to delete the subdirectory. Note that because it has been
            ' moved, an exception is thrown.
            dis.Delete(True)
        Catch
            ' Handle this exception in some way, such as with the following code:
            ' Console.WriteLine("That directory does not exist.");
            ' Point the DirectoryInfo reference to the new directory.
            ' di = New DirectoryInfo("NewTempDir")
            ' Delete the directory.
            ' di.Delete(True)        
        End Try

    End Sub 'Main
End Class 'MoveToTest
'</snippet1>