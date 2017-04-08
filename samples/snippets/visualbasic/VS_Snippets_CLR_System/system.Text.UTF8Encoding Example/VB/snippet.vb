' <Snippet1>
Imports System.Text

Class Example
    Public Shared Sub Main()
        ' Create a UTF-8 encoding.
        Dim utf8 As New UTF8Encoding()
        
        ' A Unicode string with two characters outside an 8-bit code range.
        Dim unicodeString As String = _
            "This Unicode string has 2 characters outside the " &
            "ASCII range: " & vbCrLf &
            "Pi (" & ChrW(&h03A0) & "), and Sigma (" & ChrW(&h03A3) & ")."
        Console.WriteLine("Original string:")
        Console.WriteLine(unicodeString)
        
        ' Encode the string.
        Dim encodedBytes As Byte() = utf8.GetBytes(unicodeString)
        Console.WriteLine()
        Console.WriteLine("Encoded bytes:")
        For ctr As Integer = 0 To encodedBytes.Length - 1
            Console.Write("{0:X2} ", encodedBytes(ctr))
            If (ctr + 1) Mod 25 = 0 Then Console.WriteLine
        Next
        Console.WriteLine()
        
        ' Decode bytes back to string.
        Dim decodedString As String = utf8.GetString(encodedBytes)
        Console.WriteLine()
        Console.WriteLine("Decoded bytes:")
        Console.WriteLine(decodedString)
    End Sub
End Class
' The example displays the following output:
'    Original string:
'    This Unicode string has 2 characters outside the ASCII range:
'    Pi (π), and Sigma (Σ).
'
'    Encoded bytes:
'    54 68 69 73 20 55 6E 69 63 6F 64 65 20 73 74 72 69 6E 67 20 68 61 73 20 32
'    20 63 68 61 72 61 63 74 65 72 73 20 6F 75 74 73 69 64 65 20 74 68 65 20 41
'    53 43 49 49 20 72 61 6E 67 65 3A 20 0D 0A 50 69 20 28 CE A0 29 2C 20 61 6E
'    64 20 53 69 67 6D 61 20 28 CE A3 29 2E
'
'    Decoded bytes:
'    This Unicode string has 2 characters outside the ASCII range:
'    Pi (π), and Sigma (Σ).
' </Snippet1>
