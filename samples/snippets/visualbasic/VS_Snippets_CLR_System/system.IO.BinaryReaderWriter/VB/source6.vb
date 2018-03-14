'<snippet7>
Imports System
Imports System.IO

Class MyStream
    Private Const FILE_NAME As String = "Test.data"

    Public Shared Sub Main()
        If File.Exists(FILE_NAME) Then
            Console.WriteLine("{0} already exists!", FILE_NAME)
            Return
        End If

        Using fs As New FileStream(FILE_NAME, FileMode.CreateNew)
            Using w As New BinaryWriter(fs)
                For i As Integer = 0 To 10
                    w.Write(i)
                Next
            End Using
        End Using

        Using fs As New FileStream(FILE_NAME, FileMode.Open, FileAccess.Read)
            Using r As New BinaryReader(fs)
                For i As Integer = 0 To 10
                    Console.WriteLine(r.ReadInt32())
                Next
            End Using
        End Using
    End Sub
End Class
'</snippet7>
