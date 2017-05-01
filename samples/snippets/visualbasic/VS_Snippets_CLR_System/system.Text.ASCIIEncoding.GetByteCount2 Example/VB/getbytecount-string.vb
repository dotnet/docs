 ' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample
    Public Shared Sub Main()
        Dim chars As String = "ASCII Encoding Example"

        Dim ascii As New ASCIIEncoding()
        Dim byteCount As Integer = ascii.GetByteCount(chars)
        Console.WriteLine("{0} bytes needed to encode string.", byteCount)
    End Sub
End Class
' </Snippet1>
