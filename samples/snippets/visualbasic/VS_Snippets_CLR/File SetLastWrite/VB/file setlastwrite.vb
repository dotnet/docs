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
            Else
                ' Take an action that will affect the write time.
                File.SetLastWriteTime(path, New DateTime(1985, 4, 3))
            End If

            ' Get the creation time of a well-known directory.
            Dim dt As DateTime = File.GetLastWriteTime(path)
            Console.WriteLine("The last write time for this file was {0}.", dt)

            ' Update the last write time.
            File.SetLastWriteTime(path, DateTime.Now)
            dt = File.GetLastWriteTime(path)
            Console.WriteLine("The last write time for this file was {0}.", dt)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
