' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Try
            Dim path As String = "c:\MyDir"
            If Directory.Exists(path) = False Then
                Directory.CreateDirectory(path)
            End If
            Directory.SetLastAccessTime(path, New DateTime(1985, 5, 4))

            'Get the access time of a well-known directory.
            Dim dt As DateTime = Directory.GetLastAccessTime(path)
            Console.WriteLine("The last access time for this directory was {0}", dt)

            'Update the last access time.
            Directory.SetLastAccessTime(path, DateTime.Now)
            dt = Directory.GetLastAccessTime(path)
            Console.WriteLine("The last access time for this directory was {0}", dt)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>