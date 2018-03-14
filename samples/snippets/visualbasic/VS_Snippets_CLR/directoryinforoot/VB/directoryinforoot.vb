' <snippet1>
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
        Console.WriteLine("The root path of '{0}' is '{1}'", dis.Name, dis.Root)

        ' Delete the parent directory.
        di.Delete(True)
    End Sub 'Main
End Class 'MoveToTest
' </snippet1>