 ' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample
   
    Public Shared Sub Main()
        Dim bytes() As Byte
        Dim chars As String = "ASCII Encoding Example"

        Dim ascii As New ASCIIEncoding()

        Dim byteCount As Integer = ascii.GetByteCount(chars.ToCharArray(), 6, 8)
        bytes = New Byte(byteCount - 1) {}
        Dim bytesEncodedCount As Integer = ascii.GetBytes(chars, 6, 8, bytes, 0)

        Console.WriteLine("{0} bytes used to encode string.", bytesEncodedCount)

        Console.Write("Encoded bytes: ")
        Dim b As Byte
        For Each b In bytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
    End Sub
End Class
' </Snippet1>
