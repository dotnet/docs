' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        ' Specify the directories you want to manipulate.
        Dim di As DirectoryInfo = New DirectoryInfo("c:\MyDir")
        Try
            ' Determine whether the directory exists.
            If di.Exists Then
                ' Indicate that it already exists.
                Console.WriteLine("That path exists already.")
                Return
            End If

            ' Try to create the directory.
            di.Create()
            Console.WriteLine("The directory was created successfully.")

            ' Delete the directory.
            di.Delete()
            Console.WriteLine("The directory was deleted successfully.")

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
