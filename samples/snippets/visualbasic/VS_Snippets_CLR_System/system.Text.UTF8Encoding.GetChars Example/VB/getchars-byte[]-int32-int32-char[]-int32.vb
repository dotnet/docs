' <Snippet1>
Imports System
Imports System.Text

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        Dim chars() As Char
        Dim bytes() As Byte = { _
            85,  84,  70,  56,  32,  69, 110, _
            99, 111, 100, 105, 110, 103,  32, _
            69, 120,  97, 109, 112, 108, 101 _
        }
        
        Dim utf8 As New UTF8Encoding()
        
        Dim charCount As Integer = utf8.GetCharCount(bytes, 2, 13)
        chars = New Char(charCount - 1) {}
        Dim charsDecodedCount As Integer = utf8.GetChars(bytes, 2, 13, chars, 0)
        
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
