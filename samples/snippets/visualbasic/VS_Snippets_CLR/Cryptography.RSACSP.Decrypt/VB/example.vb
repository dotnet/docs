'<SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text

Module RSACSPExample

    Sub Main()
        Try
            'Create a UnicodeEncoder to convert between byte array and string.
            Dim ByteConverter As New ASCIIEncoding

            Dim dataString As String = "Data to Encrypt"

            'Create byte arrays to hold original, encrypted, and decrypted data.
            Dim dataToEncrypt As Byte() = ByteConverter.GetBytes(dataString)
            Dim encryptedData() As Byte
            Dim decryptedData() As Byte

            'Create a new instance of the RSACryptoServiceProvider class 
            ' and automatically create a new key-pair.
            Dim RSAalg As New RSACryptoServiceProvider

            'Display the origianl data to the console.
            Console.WriteLine("Original Data: {0}", dataString)

            'Encrypt the byte array and specify no OAEP padding.  
            'OAEP padding is only available on Microsoft Windows XP or
            'later.  
            encryptedData = RSAalg.Encrypt(dataToEncrypt, False)

            'Display the encrypted data to the console. 
            Console.WriteLine("Encrypted Data: {0}", ByteConverter.GetString(encryptedData))

            'Pass the data to ENCRYPT and boolean flag specifying 
            'no OAEP padding.
            decryptedData = RSAalg.Decrypt(encryptedData, False)

            'Display the decrypted plaintext to the console. 
            Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData))
        Catch e As CryptographicException
            'Catch this exception in case the encryption did
            'not succeed.
            Console.WriteLine(e.Message)
        End Try
    End Sub 

End Module
'</SNIPPET1>