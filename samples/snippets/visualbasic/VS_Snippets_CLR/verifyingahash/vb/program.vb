'<Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Text

Module Module1
    Sub Main()
        'This hash value is produced from "This is the original message!" 
        'using SHA1Managed.  
        Dim SentHashValue As Byte() = {59, 4, 248, 102, 77, 97, 142, 201, 210, 12, 224, 93, 25, 41, 100, 197, 213, 134, 130, 135}

        'This is the string that corresponds to the previous hash value.
        Dim MessageString As String = "This is the original message!"

        Dim CompareHashValue() As Byte

        'Create a new instance of the UnicodeEncoding class to 
        'convert the string into an array of Unicode bytes.
        Dim UE As New UnicodeEncoding()

        'Convert the string into an array of bytes.
        Dim MessageBytes As Byte() = UE.GetBytes(MessageString)

        'Create a new instance of the SHA1Managed class to create 
        'the hash value.
        Dim SHhash As New SHA1Managed()

        'Create the hash value from the array of bytes.
        CompareHashValue = SHhash.ComputeHash(MessageBytes)

        Dim Same As Boolean = True

        'Compare the values of the two byte arrays.
        Dim x As Integer
        For x = 0 To SentHashValue.Length - 1
            If SentHashValue(x) <> CompareHashValue(x) Then
                Same = False
            End If
        Next x
        'Display whether or not the hash values are the same.
        If Same Then
            Console.WriteLine("The hash codes match.")
        Else
            Console.WriteLine("The hash codes do not match.")
        End If
    End Sub
End Module
'</Snippet1>

