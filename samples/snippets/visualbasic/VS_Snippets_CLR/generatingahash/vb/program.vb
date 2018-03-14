'<Snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Text

Module Program
    Sub Main()
        Dim HashValue() As Byte

        Dim MessageString As String = "This is the original message!"

        'Create a new instance of the UnicodeEncoding class to 
        'convert the string into an array of Unicode bytes.
        Dim UE As New UnicodeEncoding()

        'Convert the string into an array of bytes.
        Dim MessageBytes As Byte() = UE.GetBytes(MessageString)

        'Create a new instance of the SHA1Managed class to create 
        'the hash value.
        Dim SHhash As New SHA1Managed()

        'Create the hash value from the array of bytes.
        HashValue = SHhash.ComputeHash(MessageBytes)

        'Display the hash value to the console. 
        Dim b As Byte
        For Each b In HashValue
            Console.Write("{0} ", b)
        Next b
    End Sub
End Module
'</Snippet1>
