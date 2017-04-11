' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample
    Public Shared Sub Main()
        Dim ascii As New ASCIIEncoding()
        Dim charCount As Integer = 2
        Dim maxByteCount As Integer = ascii.GetMaxByteCount(charCount)
        Console.WriteLine( _
            "Maximum of {0} bytes needed to encode {1} characters.", _
            maxByteCount, _
            charCount _
        )
    End Sub
End Class
' </Snippet1>
