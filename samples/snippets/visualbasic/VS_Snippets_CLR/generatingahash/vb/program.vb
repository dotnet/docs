'<Snippet1>
Imports System.Security.Cryptography
Imports System.Text

Module Program
    Sub Main()
        Dim hashValue() As Byte

        Dim messageString As String = "This is the original message!"

        'Create a new instance of the UnicodeEncoding class to 
        'convert the string into an array of Unicode bytes.
        Dim ue As New UnicodeEncoding()

        'Convert the string into an array of bytes.
        Dim messageBytes As Byte() = ue.GetBytes(messageString)

        'Create a new instance of the SHA256 class to create 
        'the hash value.
        Dim shHash As SHA256 = SHA256.Create()

        'Create the hash value from the array of bytes.
        hashValue = shHash.ComputeHash(messageBytes)

        'Display the hash value to the console. 
        Dim b As Byte
        For Each b In hashValue
            Console.Write("{0} ", b)
        Next b
    End Sub
End Module
'</Snippet1>
