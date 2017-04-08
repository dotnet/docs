' <Snippet1>
Imports System
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte
        Dim chars As String = "Unicode Encoding Example"
        
        Dim uni As New UnicodeEncoding()
        
        Dim byteCount As Integer = uni.GetByteCount(chars.ToCharArray(), 8, 8)
        bytes = New Byte(byteCount - 1) {}
        Dim bytesEncodedCount As Integer = uni.GetBytes(chars, 8, 8, bytes, 0)
        
        Console.WriteLine("{0} bytes used to encode string.", bytesEncodedCount)
        
        Console.Write("Encoded bytes: ")
        Dim b As Byte
        For Each b In  bytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
    End Sub 'Main
End Class 'UnicodeEncodingExample
' </Snippet1>
