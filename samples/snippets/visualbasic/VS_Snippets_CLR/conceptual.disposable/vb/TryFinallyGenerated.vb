Imports System.IO

Module TryFinallyGenerated
    Public Sub Main()
        Dim buffer(49) As Char
        Dim streamReader As New StreamReader("File1.txt")
        Try
            Dim charsRead As Integer
            Do While streamReader.Peek() <> -1
                charsRead = streamReader.Read(buffer, 0, buffer.Length)
                ' 
                ' Process characters read.
                '
            Loop
        Finally
            If streamReader IsNot Nothing Then DirectCast(streamReader, IDisposable).Dispose()
        End Try
    End Sub
End Module
