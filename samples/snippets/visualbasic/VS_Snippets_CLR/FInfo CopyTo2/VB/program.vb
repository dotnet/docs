' <Snippet1>
Imports System
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        'Specify the directories you want to manipulate.
        Dim path As String = "c:\SourceFile.txt"
        Dim path2 As String = "c:\NewFile.txt"
        Dim fi As FileInfo = New FileInfo(path)
        Dim fi2 As FileInfo = New FileInfo(path2)

        Try
            Using fs As FileStream = fi.Create()
            End Using

            'Ensure that the target does not exist.
            If File.Exists(path2) Then
                fi2.Delete()
            End If
            
            'Copy the file.
            fi.CopyTo(path2)
            Console.WriteLine("{0} was copied to {1}.", path, path2)

        Catch ioex As IOException
            Console.WriteLine(ioex.Message)
        End Try
    End Sub
End Class
' </Snippet1>
