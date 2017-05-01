' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample
    Public Shared Sub Main()
        Dim chars() As Char
        Dim bytes() As Byte = { _
             65,  83,  67,  73,  73,  32,  69, _
            110,  99, 111, 100, 105, 110, 103, _
             32,  69, 120,  97, 109, 112, 108, 101}

        Dim ascii As New ASCIIEncoding()

        Dim charCount As Integer = ascii.GetCharCount(bytes, 6, 8)
        chars = New Char(charCount - 1) {}
        Dim charsDecodedCount As Integer = ascii.GetChars(bytes, 6, 8, chars, 0)

        Console.WriteLine("{0} characters used to decode bytes.", charsDecodedCount)

        Console.Write("Decoded chars: ")
        Dim c As Char
        For Each c In chars
            Console.Write("[{0}]", c)
        Next c
        Console.WriteLine()
    End Sub
End Class
' </Snippet1>
