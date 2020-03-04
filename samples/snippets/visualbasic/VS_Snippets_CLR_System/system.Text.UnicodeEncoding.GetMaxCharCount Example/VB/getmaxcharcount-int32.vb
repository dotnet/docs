' <Snippet1>
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim uni As New UnicodeEncoding()
        Dim byteCount As Integer = 8
        Dim maxCharCount As Integer = uni.GetMaxCharCount(byteCount)
        Console.WriteLine("Maximum of {0} characters needed to decode {1} bytes.", maxCharCount, byteCount)
    End Sub
End Class
' </Snippet1>
