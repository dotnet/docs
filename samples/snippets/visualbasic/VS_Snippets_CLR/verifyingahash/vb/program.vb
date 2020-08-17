'<Snippet1>
Imports System.Security.Cryptography
Imports System.Text

Module Module1
    Sub Main()
        'This hash value is produced from "This is the original message!" 
        'using SHA256.  
        Dim sentHashValue As Byte() = {185, 203, 236, 22, 3, 228, 27, 130, 87, 23, 244, 15, 87, 88, 14, 43, 37, 61, 106, 224, 81, 172, 224, 211, 104, 85, 194, 197, 194, 25, 120, 217}

        'This is the string that corresponds to the previous hash value.
        Dim messageString As String = "This is the original message!"

        Dim compareHashValue() As Byte

        'Create a new instance of the UnicodeEncoding class to 
        'convert the string into an array of Unicode bytes.
        Dim ue As New UnicodeEncoding()

        'Convert the string into an array of bytes.
        Dim messageBytes As Byte() = ue.GetBytes(messageString)

        'Create a new instance of the SHA1Managed class to create 
        'the hash value.
        Dim shHash As SHA256 = SHA256.Create()

        'Create the hash value from the array of bytes.
        compareHashValue = shHash.ComputeHash(messageBytes)

        Dim same As Boolean = True

        'Compare the values of the two byte arrays.
        Dim x As Integer
        For x = 0 To sentHashValue.Length - 1
            If sentHashValue(x) <> compareHashValue(x) Then
                same = False
            End If
        Next x
        'Display whether or not the hash values are the same.
        If same Then
            Console.WriteLine("The hash codes match.")
        Else
            Console.WriteLine("The hash codes do not match.")
        End If
    End Sub
End Module
'</Snippet1>

