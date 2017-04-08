' <snippet1>
Imports System
Imports System.IO

Public Class CreateSubTest

    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("TempDir")

        ' Create the directory only if it does not already exist.
        If di.Exists = False Then
            di.Create()
        End If

        ' Create a subdirectory in the directory just created.
        Dim dis As DirectoryInfo = di.CreateSubdirectory("SubDir")

        ' Process that directory as required.
        ' ...

        ' Delete the subdirectory.
        dis.Delete(True)

        ' Delete the directory.
        di.Delete(True)
    End Sub 'Main
End Class 'CreateSubTest
' </snippet1>