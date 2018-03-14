' <Snippet1>
Imports System.Text

Module Example
   
    Public Sub Main()
        ' Define a string.
        Dim original As String = "ASCII Encoding Example"
        ' Instantiate an ASCII encoding object.
        Dim ascii As New ASCIIEncoding()
        
        ' Create an ASCII byte array.
        Dim bytes() As Byte = ascii.GetBytes(original) 
        
        ' Display encoded bytes.
        Console.Write("Encoded bytes (in hex):  ")
        For Each value In bytes
           Console.Write("{0:X2} ", value)
        Next   
        Console.WriteLine()

        ' Decode the bytes and display the resulting Unicode string.
        Dim decoded As String = ascii.GetString(bytes)
        Console.WriteLine("Decoded string: '{0}'", decoded)
    End Sub
End Module
' The example displays the following output:
'   Encoded bytes (in hex):  41 53 43 49 49 20 45 6E 63 6F 64 69 6E 67 20 45 78 61 6D 70 6C 65
'   Decoded string: 'ASCII Encoding Example'
' </Snippet1>
