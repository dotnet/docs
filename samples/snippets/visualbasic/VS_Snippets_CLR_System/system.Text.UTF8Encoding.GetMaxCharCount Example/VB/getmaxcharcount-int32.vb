' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim utf8 As New UTF8Encoding()
        Dim byteCount As Integer = 8
        Dim maxCharCount As Integer = utf8.GetMaxCharCount(byteCount)
        Console.WriteLine( _
            "Maximum of {0} characters needed to decode {1} bytes.", _
            maxCharCount, _
            byteCount _
        )
    End Sub 'Main
End Class 'UTF8EncodingExample
' </Snippet1>
