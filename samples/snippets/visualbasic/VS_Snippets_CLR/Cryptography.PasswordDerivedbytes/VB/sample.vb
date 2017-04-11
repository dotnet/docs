'<SNIPPET1>
Imports System
Imports System.Security.Cryptography
Imports System.Text



Module PasswordDerivedBytesExample


    Sub Main(ByVal args() As String)

        ' Get a password from the user.
        Console.WriteLine("Enter a password to produce a key:")

        Dim pwd As Byte() = Encoding.Unicode.GetBytes(Console.ReadLine())

        Dim salt As Byte() = CreateRandomSalt(7)

        ' Create a TripleDESCryptoServiceProvider object.
        Dim tdes As New TripleDESCryptoServiceProvider()

        Try
            Console.WriteLine("Creating a key with PasswordDeriveBytes...")

            ' Create a PasswordDeriveBytes object and then create 
            ' a TripleDES key from the password and salt.
            Dim pdb As New PasswordDeriveBytes(pwd, salt)

            ' <Snippet2>

            ' Create the key and set it to the Key property
            ' of the TripleDESCryptoServiceProvider object.
            tdes.Key = pdb.CryptDeriveKey("TripleDES", "SHA1", 192, tdes.IV)
            ' </Snippet2>


            Console.WriteLine("Operation complete.")
        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally
            ' Clear the buffers
            ClearBytes(pwd)
            ClearBytes(salt)

            ' Clear the key.
            tdes.Clear()
        End Try

        Console.ReadLine()

    End Sub


    '********************************************************
    '* Helper methods:
    '* createRandomSalt: Generates a random salt value of the 
    '*                   specified length.  
    '*
    '* clearBytes: Clear the bytes in a buffer so they can't 
    '*             later be read from memory.
    '********************************************************
    Function CreateRandomSalt(ByVal length As Integer) As Byte()
        ' Create a buffer
        Dim randBytes() As Byte

        If length >= 1 Then
            randBytes = New Byte(length) {}
        Else
            randBytes = New Byte(0) {}
        End If

        ' Create a new RNGCryptoServiceProvider.
        Dim rand As New RNGCryptoServiceProvider()

        ' Fill the buffer with random bytes.
        rand.GetBytes(randBytes)

        ' return the bytes.
        Return randBytes

    End Function


    Sub ClearBytes(ByVal buffer() As Byte)
        ' Check arguments.
        If buffer Is Nothing Then
            Throw New ArgumentException("buffer")
        End If

        ' Set each byte in the buffer to 0.
        Dim x As Integer
        For x = 0 To buffer.Length - 1
            buffer(x) = 0
        Next x

    End Sub
End Module
'</SNIPPET1>