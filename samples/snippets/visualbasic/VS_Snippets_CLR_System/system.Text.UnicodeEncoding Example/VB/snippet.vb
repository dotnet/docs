 ' <Snippet1>
Imports System
Imports System.Text
Imports Microsoft.VisualBasic.Strings

Class UnicodeEncodingExample
    
    Public Shared Sub Main()
        ' The encoding.
        Dim uni As New UnicodeEncoding()
        
        ' Create a string that contains Unicode characters.
        Dim unicodeString As String = _
            "This Unicode string contains two characters " & _
            "with codes outside the traditional ASCII code range, " & _
            "Pi (" & ChrW(928) & ") and Sigma (" & ChrW(931) & ")."
        Console.WriteLine("Original string:")
        Console.WriteLine(unicodeString)
        
        ' Encode the string.
        Dim encodedBytes As Byte() = uni.GetBytes(unicodeString)
        Console.WriteLine()
        Console.WriteLine("Encoded bytes:")
        Dim b As Byte
        For Each b In  encodedBytes
            Console.Write("[{0}]", b)
        Next b
        Console.WriteLine()
        
        ' Decode bytes back to string.
        ' Notice Pi and Sigma characters are still present.
        Dim decodedString As String = uni.GetString(encodedBytes)
        Console.WriteLine()
        Console.WriteLine("Decoded bytes:")
        Console.WriteLine(decodedString)
    End Sub
End Class
' </Snippet1>
