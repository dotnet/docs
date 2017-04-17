' <Snippet1>
Imports System
Imports System.Text

Class EncoderExample
    
    Public Shared Sub Main()
        ' An Encoder is obtained from an Encoding.
        Dim uni As New UnicodeEncoding()
        Dim enc1 As Encoder = uni.GetEncoder()
        
        ' A more direct technique.
        Dim enc2 As Encoder = Encoding.Unicode.GetEncoder()
        
        ' enc1 and enc2 seem the same.
        Console.WriteLine(enc1.ToString())
        Console.WriteLine(enc2.ToString())
        
        ' Note that their hash codes differ.
        Console.WriteLine(enc1.GetHashCode())
        Console.WriteLine(enc2.GetHashCode())
    End Sub 'Main
End Class 'EncoderExample

'This code example produces the following output.
'System.Text.EncoderNLS
'System.Text.EncoderNLS
'58225482
'54267293
'
' </Snippet1>
