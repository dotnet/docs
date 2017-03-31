' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class UTF8EncodingExample
    
    Public Shared Sub Main()
        'Characters:
        ' ChrW(97) = a
        ' ChrW(98) = b
        ' ChrW(99) = c
        ' ChrW(768) = `
        ' ChrW(41120) = valid unicode code point, but not a character
        Dim chars() As Char = {ChrW(97), ChrW(98), ChrW(99), ChrW(768), ChrW(41120)}
        Dim bytes() As Byte
        
        Dim utf8Encoder As Encoder = Encoding.UTF8.GetEncoder()
        
        Dim byteCount As Integer = utf8Encoder.GetByteCount(chars, 2, 3, True)
        bytes = New Byte(byteCount - 1) {}
        Dim bytesEncodedCount As Integer = utf8Encoder.GetBytes( _
            chars, 2, 3, bytes, 0, True _
        )
        
        Console.WriteLine("{0} bytes used to encode characters.", bytesEncodedCount)
        
        Console.Write("Encoded bytes: ")
        Dim b As Byte
        For Each b In  bytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
    End Sub 'Main
End Class 'UTF8EncodingExample
' </Snippet1>
