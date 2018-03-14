' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"
        Dim path2 As String = "c:\temp2\MyTest.txt"

        Try
            If File.Exists(path) = False Then
                ' This statement ensures that the file is created,
                ' but the handle is not kept.
                Dim fs As FileStream = File.Create(path)
                fs.Close()
            End If

            ' Ensure that the target does not exist.
            If File.Exists(path2) Then
                File.Delete(path2)
            End If

            ' Move the file.
            File.Move(path, path2)
            Console.WriteLine("{0} moved to {1}", path, path2)

            ' See if the original file exists now.
            If File.Exists(path) Then
                Console.WriteLine("The original file still exists, which is unexpected.")
            Else
                Console.WriteLine("The original file no longer exists, which is expected.")
            End If
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
