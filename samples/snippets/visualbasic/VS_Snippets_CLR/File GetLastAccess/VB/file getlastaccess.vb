' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
    Public Shared Sub Main()
        Try
            Dim path As String = "c:\Temp\MyTest.txt"
            If File.Exists(path) = False Then
                File.Create(path)
            End If
            File.SetLastAccessTime(path, New DateTime(1985, 5, 4))

            ' Get the creation time of a well-known directory.
            Dim dt As DateTime = File.GetLastAccessTime(path)

            Console.WriteLine("The last access time for this file was {0}.", dt)

            ' Update the last access time.
            File.SetLastAccessTime(path, DateTime.Now)
            dt = File.GetLastAccessTime(path)
            Console.WriteLine("The last access time for this file was {0}.", dt)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
