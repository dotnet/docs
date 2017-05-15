' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample
    Public Shared Sub Main()
        Dim ascii As New ASCIIEncoding()
        Dim byteCount As Integer = 8
        Dim maxCharCount As Integer = ascii.GetMaxCharCount(byteCount)
        Console.WriteLine( _
            "Maximum of {0} characters needed to decode {1} bytes.", _
            maxCharCount, _
            byteCount _
        )
    End Sub
End Class
' </Snippet1>
