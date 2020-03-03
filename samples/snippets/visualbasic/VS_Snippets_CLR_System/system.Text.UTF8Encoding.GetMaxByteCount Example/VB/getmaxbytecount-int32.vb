' <Snippet1>
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim utf8 As New UTF8Encoding()
        Dim charCount As Integer = 2
        Dim maxByteCount As Integer = utf8.GetMaxByteCount(charCount)
        Console.WriteLine( _
            "Maximum of {0} bytes needed to encode {1} characters.", _
            maxByteCount, _
            charCount _
        )
    End Sub
End Class
' </Snippet1>
