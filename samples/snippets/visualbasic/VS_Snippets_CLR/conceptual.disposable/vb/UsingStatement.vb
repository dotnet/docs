Imports System.IO

Module UsingStatement
    Public Sub Main()
        Dim buffer(49) As Char
        Using streamReader As New StreamReader("File1.txt")
            Dim charsRead As Integer
            Do While streamReader.Peek() <> -1
                charsRead = streamReader.Read(buffer, 0, buffer.Length)
                ' 
                ' Process characters read.
                '
            Loop
        End Using
    End Sub
End Module
