' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class UTF7EncodingExample
    
    Public Shared Sub Main()
        ' Create a UTF-7 encoding.
        Dim utf7 As New UTF7Encoding()
        
        ' A Unicode string with two characters outside a 7-bit code range.
        Dim unicodeString As String = _
            "This Unicode string contains two characters " & _
            "with codes outside a 7-bit code range, " & _
            "Pi (" & ChrW(928) & ") and Sigma (" & ChrW(931) & ")."
        Console.WriteLine("Original string:")
        Console.WriteLine(unicodeString)
        
        ' Encode the string.
        Dim encodedBytes As Byte() = utf7.GetBytes(unicodeString)
        Console.WriteLine()
        Console.WriteLine("Encoded bytes:")
        Dim b As Byte
        For Each b In  encodedBytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
        
        ' Decode bytes back to string.
        ' Notice Pi and Sigma characters are still present.
        Dim decodedString As String = utf7.GetString(encodedBytes)
        Console.WriteLine()
        Console.WriteLine("Decoded bytes:")
        Console.WriteLine(decodedString)
    End Sub
End Class
' </Snippet1>
