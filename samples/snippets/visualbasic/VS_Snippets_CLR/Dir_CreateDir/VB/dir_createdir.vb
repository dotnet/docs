' <Snippet1>
Imports System
Imports System.IO
Imports Microsoft.VisualBasic

Public Class Test
    Public Shared Sub Main()
        ' Specify the directory you want to manipulate.
        Dim path As String = "c:\MyDir"

        Try
            ' Determine whether the directory exists.
            If Directory.Exists(path) Then
                Console.WriteLine("That path exists already.")
                Return
            End If

            ' Try to create the directory.
            Dim di As DirectoryInfo = Directory.CreateDirectory(path)
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path))

            ' Delete the directory.
            di.Delete()
            Console.WriteLine("The directory was deleted successfully.")

        Catch e As Exception
            Console.WriteLine("The process failed: {0}.", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>