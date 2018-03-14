' <Snippet1>
Imports System
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim chars() As Char
        Dim bytes() As Byte = {85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0}
        
        Dim uni As New UnicodeEncoding()
        
        Dim charCount As Integer = uni.GetCharCount(bytes, 2, 8)
        chars = New Char(charCount - 1) {}
        Dim charsDecodedCount As Integer = uni.GetChars(bytes, 2, 8, chars, 0)
        
        Console.WriteLine("{0} characters used to decode bytes.", charsDecodedCount)
        
        Console.Write("Decoded chars: ")
        Dim c As Char
        For Each c In  chars
            Console.Write("[{0}]", c)
        Next c
        Console.WriteLine()
    End Sub 'Main
End Class 'UnicodeEncodingExample
' </Snippet1>
