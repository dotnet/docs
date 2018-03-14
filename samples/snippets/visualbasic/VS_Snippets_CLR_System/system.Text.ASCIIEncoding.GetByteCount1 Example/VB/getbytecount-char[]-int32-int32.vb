' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class ASCIIEncodingExample
    Public Shared Sub Main()
        ' Unicode characters.
        ' ChrW(35)  = #
        ' ChrW(37)  = %
        ' ChrW(928) = Pi
        ' ChrW(931) = Sigma
        Dim chars() As Char = {ChrW(35), ChrW(37), ChrW(928), ChrW(931)}

        Dim ascii As New ASCIIEncoding()
        Dim byteCount As Integer = ascii.GetByteCount(chars, 1, 2)
        Console.WriteLine("{0} bytes needed to encode characters.", byteCount)
    End Sub
End Class
' </Snippet1>
