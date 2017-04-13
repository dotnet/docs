' <Snippet1>
Imports System
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim uni As New UnicodeEncoding()
        Dim charCount As Integer = 2
        Dim maxByteCount As Integer = uni.GetMaxByteCount(charCount)
        Console.WriteLine("Maximum of {0} bytes needed to encode {1} characters.", maxByteCount, charCount)
    End Sub 'Main
End Class 'UnicodeEncodingExample
' </Snippet1>
