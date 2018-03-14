' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte
        Dim chars As String = "UTF8 Encoding Example"
        
        Dim utf8 As New UTF8Encoding()
        
        Dim byteCount As Integer = utf8.GetByteCount(chars.ToCharArray(), 0, 13)
        bytes = New Byte(byteCount - 1) {}
        Dim bytesEncodedCount As Integer = utf8.GetBytes(chars, 0, 13, bytes, 0)
        
        Console.WriteLine("{0} bytes used to encode string.", bytesEncodedCount)
        
        Console.Write("Encoded bytes: ")
        Dim b As Byte
        For Each b In  bytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
    End Sub 'Main
End Class 'UTF8EncodingExample
' </Snippet1>
