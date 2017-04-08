' <Snippet1>
Imports System
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte = {85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0}
        
        Dim uni As New UnicodeEncoding()
        Dim charCount As Integer = uni.GetCharCount(bytes, 2, 8)
        Console.WriteLine("{0} characters needed to decode bytes.", charCount)
    End Sub 'Main
End Class 'UnicodeEncodingExample
' </Snippet1>
