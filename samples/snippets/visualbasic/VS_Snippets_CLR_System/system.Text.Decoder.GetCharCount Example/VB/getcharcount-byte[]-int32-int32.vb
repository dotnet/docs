' <Snippet1>
Imports System
Imports System.Text

Class DecoderExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte = { _
            85, 0, 110, 0, 105, 0, 99, 0, 111, 0, 100, 0, 101, 0 _
        }
        
        Dim uniDecoder As Decoder = Encoding.Unicode.GetDecoder()
        Dim charCount As Integer = uniDecoder.GetCharCount(bytes, 0, bytes.Length)
        Console.WriteLine("{0} characters needed to decode bytes.", charCount)
    End Sub
End Class

'This code example produces the following output.
'
'7 characters needed to decode bytes.
'
' </Snippet1>
