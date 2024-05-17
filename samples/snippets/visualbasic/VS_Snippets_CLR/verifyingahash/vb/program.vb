'<Snippet1>
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text

Module Module1
    Sub Main()
        'This hash value is produced from "This is the original message!" 
        'using SHA256.  
        Dim sentHashValue As Byte() = Convert.FromHexString("67A1790DCA55B8803AD024EE28F616A284DF5DD7B8BA5F68B4B252A5E925AF79")

        'This is the string that corresponds to the previous hash value.
        Dim messageString As String = "This is the original message!"

        'Convert the string into an array of bytes.
        Dim messageBytes As Byte() = Encoding.UTF8.GetBytes(messageString)

        'Create the hash value from the array of bytes.
        Dim compareHashValue As Byte() = SHA256.HashData(messageBytes)

        'Compare the values of the two byte arrays.
        Dim same As Boolean = sentHashValue.SequenceEqual(compareHashValue)

        'Display whether or not the hash values are the same.
        If same Then
            Console.WriteLine("The hash codes match.")
        Else
            Console.WriteLine("The hash codes do not match.")
        End If
    End Sub
End Module
'</Snippet1>

