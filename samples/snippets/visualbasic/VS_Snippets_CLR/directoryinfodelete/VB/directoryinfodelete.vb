' <snippet1>
Imports System
Imports System.IO

Public Class DeleteTest

    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("TempDir")

        ' Create the directory only if it does not already exist.
        If di.Exists = False Then
            di.Create()
        End If

        Dim dis As DirectoryInfo = di.CreateSubdirectory("SubDir")
        ' Create a subdirectory in the directory just created.

        ' Process that directory as required.
        ' ...

        ' Delete the subdirectory. The true indicates that if subdirectories
        ' or files are in this directory, they are to be deleted as well.
        dis.Delete(True)

        ' Delete the directory.
        di.Delete(True)
    End Sub 'Main
End Class 'DeleteTest
' </snippet1>