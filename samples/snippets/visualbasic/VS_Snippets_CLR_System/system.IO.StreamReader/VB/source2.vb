'<snippet20>
Imports System.IO

Public Class CompBuf
    Private Const FILE_NAME As String = "MyFile.txt"

    Public Shared Sub Main()
        If Not File.Exists(FILE_NAME) Then
            Console.WriteLine($"{FILE_NAME} does not exist!")
            Return
        End If
        Dim fsIn As new FileStream(FILE_NAME, FileMode.Open, _
            FileAccess.Read, FileShare.Read)
        ' Create an instance of StreamReader that can read
        ' characters from the FileStream.
        Using sr As New StreamReader(fsIn)
            Dim input As String
            ' While not at the end of the file, read lines from the file.
            While sr.Peek() > -1
                input = sr.ReadLine()
                Console.WriteLine(input)
            End While
        End Using
    End Sub
End Class
'</snippet20>
