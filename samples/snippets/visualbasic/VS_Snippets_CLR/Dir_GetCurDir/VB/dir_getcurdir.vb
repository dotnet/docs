' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Try
            ' Get the current directory.
            Dim path As String = Directory.GetCurrentDirectory()
            Dim target As String = "c:\temp"
            Console.WriteLine("The current directory is {0}", path)
            If Directory.Exists(target) = False Then
                Directory.CreateDirectory(target)
            End If
            ' Change the current directory.
            Environment.CurrentDirectory = (target)
            If path.Equals(Directory.GetCurrentDirectory()) Then
                Console.WriteLine("You are in the temp directory.")
            Else
                Console.WriteLine("You are not in the temp directory.")
            End If
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>