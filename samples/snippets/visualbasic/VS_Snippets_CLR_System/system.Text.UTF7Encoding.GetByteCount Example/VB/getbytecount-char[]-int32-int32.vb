' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        ' Unicode characters.
        ' ChrW(35)  = #
        ' ChrW(37)  = %
        ' ChrW(928) = Pi
        ' ChrW(931) = Sigma
        Dim chars() As Char = {ChrW(35), ChrW(37), ChrW(928), ChrW(931)}
        
        Dim utf7 As New UTF7Encoding()
        Dim byteCount As Integer = utf7.GetByteCount(chars, 1, 2)
        Console.WriteLine("{0} bytes needed to encode characters.", byteCount)
    End Sub 'Main
End Class 'UTF7EncodingExample
' </Snippet1>
