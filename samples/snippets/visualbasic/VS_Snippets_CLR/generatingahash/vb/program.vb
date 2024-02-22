'<Snippet1>
Imports System.Security.Cryptography
Imports System.Text

Module Program
    Sub Main()
        Dim messageString As String = "This is the original message!"

        'Convert the string into an array of bytes.
        Dim messageBytes As Byte() = Encoding.UTF8.GetBytes(messageString)

        'Create the hash value from the array of bytes.
        Dim hashValue As Byte() = SHA256.HashData(messageBytes)

        'Display the hash value to the console. 
        Console.WriteLine(Convert.ToHexString(hashValue))
    End Sub
End Module
'</Snippet1>
