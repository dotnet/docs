' <Snippet1>
Imports System
Imports System.Text

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        Dim chars() As Char
        Dim bytes() As Byte = {99, 43, 65, 119, 67, 103, 111, 65, 45}
        
        Dim utf7Decoder As Decoder = Encoding.UTF7.GetDecoder()
        
        Dim charCount As Integer = utf7Decoder.GetCharCount(bytes, 0, bytes.Length)
        chars = New Char(charCount - 1) {}
        Dim charsDecodedCount As Integer = utf7Decoder.GetChars(bytes, 0, bytes.Length, chars, 0)
        
        Console.WriteLine("{0} characters used to decode bytes.", charsDecodedCount)
        
        Console.Write("Decoded chars: ")
        Dim c As Char
        For Each c In  chars
            Console.Write("[{0}]", c)
        Next c
        Console.WriteLine()
    End Sub 'Main
End Class 'UTF7EncodingExample
' </Snippet1>
