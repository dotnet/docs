'<snippet7>
Imports System.IO

Class MyStream
    Private Const FILE_NAME As String = "Test.data"

    Public Shared Sub Main()
        If File.Exists(FILE_NAME) Then
            Console.WriteLine($"{FILE_NAME} already exists!")
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

' The example creates a file named "Test.data" and writes the integers 0 through 10 to it in binary format.
' It then writes the contents of Test.data to the console with each integer on a separate line.

'</snippet7>
