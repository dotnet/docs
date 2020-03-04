' <Snippet1>
Imports System.Text

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        Dim utf7 As New UTF7Encoding()
        Dim charCount As Integer = 2
        Dim maxByteCount As Integer = utf7.GetMaxByteCount(charCount)
        Console.WriteLine( _
            "Maximum of {0} bytes needed to encode {1} characters.", _
            maxByteCount, _
            charCount _
        )
    End Sub
End Class
' </Snippet1>
