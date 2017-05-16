' <Snippet1>
Imports System
Imports System.Text

Class ASCIIEncodingExample
    Public Shared Sub Main()
        Dim bytes() As Byte = { _
             65,  83,  67,  73,  73,  32,  69, _
            110,  99, 111, 100, 105, 110, 103, _
             32,  69, 120,  97, 109, 112, 108, 101}
      
        Dim ascii As New ASCIIEncoding()
        Dim charCount As Integer = ascii.GetCharCount(bytes, 6, 8)
        Console.WriteLine("{0} characters needed to decode bytes.", charCount)
    End Sub
End Class
' </Snippet1>
