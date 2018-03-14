' <Snippet1>
Imports System
Imports System.IO

Public Class Block
    Public Shared Sub Main()
        Dim s As Stream = New MemoryStream()
        For i As Integer = 0 To 121
            s.WriteByte(CType(i, Byte))
        Next i
        s.Position = 0

        ' Now read s into a byte buffer that is padded slightly.
        Dim bytes(s.Length + 10) As Byte
        Dim numBytesToRead As Integer = s.Length
        Dim numBytesRead As Integer = 0
        Dim n As Integer
        Do
            ' Read may return anything from 0 to 10.
            n = s.Read(bytes, numBytesRead, 10)
            ' The end of the file is reached.
            numBytesRead += n
            numBytesToRead -= n
        Loop While numBytesToRead > 0

        s.Close()
    
        Console.WriteLine("number of bytes read: {0:d}", numBytesRead)
    End Sub
End Class
' </Snippet1>
