'<snippet21>
Imports System.IO

Public Class ReadBuf
    Private Const FILE_NAME As String = "MyFile.txt"

    Public Shared Sub Main()
        If Not File.Exists(FILE_NAME) Then
            Console.WriteLine($"{FILE_NAME} does not exist.")
            Return
        End If
        Dim f As New FileStream(FILE_NAME, FileMode.Open, _
            FileAccess.Read, FileShare.Read)
        ' Create an instance of BinaryReader that can
        ' read bytes from the FileStream.
        Using br As new BinaryReader(f)
            Dim input As Byte
            ' While not at the end of the file, read lines from the file.
            While br.PeekChar() > -1
                input = br.ReadByte()
                Console.WriteLine(input)
            End While
        End Using
    End Sub
End Class
'</snippet21>
