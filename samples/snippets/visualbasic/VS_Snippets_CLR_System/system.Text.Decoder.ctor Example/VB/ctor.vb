' <Snippet1>
Imports System
Imports System.Text

Class EncoderExample
    
    Public Shared Sub Main()
        ' A Decoder is obtained from an Encoding.
        Dim uni As New UnicodeEncoding()
        Dim dec1 As Decoder = uni.GetDecoder()
        
        ' A more direct technique.
        Dim dec2 As Decoder = Encoding.Unicode.GetDecoder()
        
        ' dec1 and dec2 seem to be the same.
        Console.WriteLine(dec1.ToString())
        Console.WriteLine(dec2.ToString())
        
        ' Note that their hash codes differ.
        Console.WriteLine(dec1.GetHashCode())
        Console.WriteLine(dec2.GetHashCode())
    End Sub
End Class

'This code example produces the following output.
'System.Text.UnicodeEncoding+Decoder
'System.Text.UnicodeEncoding+Decoder
'58225482
'54267293
'
' </Snippet1>
