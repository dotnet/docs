' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class EncoderExample
    
    Public Shared Sub Main()
        ' Unicode characters.
        ' ChrW(35)  = #
        ' ChrW(37)  = %
        ' ChrW(928) = Pi
        ' ChrW(931) = Sigma
        Dim chars() As Char = {ChrW(35), ChrW(37), ChrW(928), ChrW(931)}
        
        Dim uniEncoder As Encoder = Encoding.Unicode.GetEncoder()
        Dim byteCount As Integer = _
            uniEncoder.GetByteCount(chars, 0, chars.Length, True)
        Console.WriteLine("{0} bytes needed to encode characters.", byteCount)
    End Sub 'Main
End Class 'EncoderExample
'
'This example produces the following output.
'
'8 bytes needed to encode characters.
'
' </Snippet1>
