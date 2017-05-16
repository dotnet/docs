'<Snippet00>
Imports System
Imports System.IO

Public Class Touch
    Public Shared Sub Main(ByVal args() As String)

        ' Make sure an argument (filename) was provided.
        If args.Length > 0 Then

            ' Verify that the provided filename exists.
            If File.Exists(args(0)) Then
                Dim fi As FileInfo = New FileInfo(args(0))
                touchFile(fi)
            Else
                Console.WriteLine("Could not find the file {0}", args(0))
            End If
        Else
            Console.WriteLine("No file specified.")
        End If
    End Sub

    Public Shared Sub touchFile(ByVal fsi As FileSystemInfo)
        Console.WriteLine("Touching: {0}", fsi.FullName)

        ' Update the CreationTime, LastWriteTime and LastAccessTime.
        Try
            fsi.CreationTime = DateTime.Now
            fsi.LastAccessTime = DateTime.Now
            fsi.LastWriteTime = DateTime.Now
        Catch e As Exception
            Console.WriteLine("Error: {0}", e.Message)
        End Try

    End Sub

End Class
'</Snippet00>