' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.strings

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        Dim bytes() As Byte
        ' Unicode characters.
        ' ChrW(35)  = #
        ' ChrW(37)  = %
        ' ChrW(928) = Pi
        ' ChrW(931) = Sigma
        Dim chars() As Char = {ChrW(35), ChrW(37), ChrW(928), ChrW(931)}
        
        Dim utf7 As New UTF7Encoding()
        
        Dim byteCount As Integer = utf7.GetByteCount(chars, 1, 2)
        bytes = New Byte(byteCount - 1) {}
        Dim bytesEncodedCount As Integer = utf7.GetBytes(chars, 1, 2, bytes, 0)
        
        Console.WriteLine("{0} bytes used to encode characters.", bytesEncodedCount)
        
        Console.Write("Encoded bytes: ")
        Dim b As Byte
        For Each b In  bytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
    End Sub 'Main
End Class 'UTF7EncodingExample
' </Snippet1>
