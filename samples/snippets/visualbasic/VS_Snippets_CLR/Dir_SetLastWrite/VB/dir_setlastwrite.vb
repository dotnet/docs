' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Try
            Dim path As String = "c:\MyDir"
            If Directory.Exists(path) = False Then
                Directory.CreateDirectory(path)
            Else
                ' Take an action that will affect the write time.
                Directory.SetLastWriteTime(path, New DateTime(1985, 4, 3))
            End If

            'Get the last write time of a well-known directory.
            Dim dt As DateTime = Directory.GetLastWriteTime(path)
            Console.WriteLine("The last write time for this directory was {0}", dt)

            'Update the last write time.
            Directory.SetLastWriteTime(path, DateTime.Now)
            dt = Directory.GetLastWriteTime(path)
            Console.WriteLine("The last write time for this directory was {0}", dt)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>