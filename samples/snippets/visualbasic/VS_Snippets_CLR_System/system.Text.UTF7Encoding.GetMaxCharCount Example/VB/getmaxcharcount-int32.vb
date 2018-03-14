' <Snippet1>
Imports System
Imports System.Text

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        Dim utf7 As New UTF7Encoding()
        Dim byteCount As Integer = 8
        Dim maxCharCount As Integer = utf7.GetMaxCharCount(byteCount)
        Console.WriteLine( _
            "Maximum of {0} characters needed to decode {1} bytes.", _
            maxCharCount, _
            byteCount _
        )
    End Sub 'Main
End Class 'UTF7EncodingExample
' </Snippet1>
