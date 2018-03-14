' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim chars() As Char
        Dim bytes() As Byte = {99, 204, 128, 234, 130, 160}
        
        Dim utf8Decoder As Decoder = Encoding.UTF8.GetDecoder()
        
        Dim charCount As Integer = utf8Decoder.GetCharCount(bytes, 0, bytes.Length)
        chars = New Char(charCount - 1) {}
        Dim charsDecodedCount As Integer = utf8Decoder.GetChars( _
            bytes, 0, bytes.Length, chars, 0 _
        )
        
        Console.WriteLine("{0} characters used to decode bytes.", charsDecodedCount)
        
        Console.Write("Decoded chars: ")
        Dim c As Char
        For Each c In  chars
            Console.Write("[{0}]", c)
        Next c
        Console.WriteLine()
    End Sub 'Main
End Class 'UTF8EncodingExample
' </Snippet1>
