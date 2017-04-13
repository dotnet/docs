' <Snippet1>
Imports System
Imports System.Text

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        Dim chars() As Char
        Dim bytes() As Byte = { _
            85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0 _
        }
        
        Dim uniDecoder As Decoder = Encoding.Unicode.GetDecoder()
        
        Dim charCount As Integer = uniDecoder.GetCharCount(bytes, 0, bytes.Length)
        chars = New Char(charCount - 1) {}
        Dim charsDecodedCount As Integer = _
            uniDecoder.GetChars(bytes, 0, bytes.Length, chars, 0)
        
        Console.WriteLine( _
            "{0} characters used to decode bytes.", _
            charsDecodedCount _
        )
        
        Console.Write("Decoded chars: ")
        Dim c As Char
        For Each c In  chars
            Console.Write("[{0}]", c)
        Next c
        Console.WriteLine()
    End Sub
End Class

'This code example produces the following output.
'
'7 characters used to decode bytes.
'Decoded chars: [U][n][i][c][o][d][e]
'
' </Snippet1>
