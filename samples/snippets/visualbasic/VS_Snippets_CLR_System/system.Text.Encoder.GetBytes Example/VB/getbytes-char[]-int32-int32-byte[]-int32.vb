' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class EncoderExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte
        ' Unicode characters.
        ' ChrW(35)  = #
        ' ChrW(37)  = %
        ' ChrW(928) = Pi
        ' ChrW(931) = Sigma
        Dim chars() As Char = {ChrW(35), ChrW(37), ChrW(928), ChrW(931)}
        
        Dim uniEncoder As Encoder = Encoding.Unicode.GetEncoder()
        
        Dim byteCount As Integer = _
            uniEncoder.GetByteCount(chars, 0, chars.Length, True)
        bytes = New Byte(byteCount - 1) {}
        Dim bytesEncodedCount As Integer = _
            uniEncoder.GetBytes(chars, 0, chars.Length, bytes, 0, True)
        
        Console.WriteLine( _
            "{0} bytes used to encode characters.", _
            bytesEncodedCount _
        )
        
        Console.Write("Encoded bytes: ")
        Dim b As Byte
        For Each b In  bytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
    End Sub 'Main
End Class 'EncoderExample

'This code example produces the following output.
'8 bytes used to encode characters.
'Encoded bytes: [35][0][37][0][160][3][163][3]
'
' </Snippet1>
