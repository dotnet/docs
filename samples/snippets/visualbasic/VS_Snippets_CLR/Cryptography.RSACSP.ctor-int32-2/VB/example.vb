'<SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text

Module RSACSPExample

    Sub Main()
        Try
            'Create a UnicodeEncoder to convert between byte array and string.
            Dim ByteConverter As New UnicodeEncoding

            'Create byte arrays to hold original, encrypted, and decrypted data.
            Dim dataToEncrypt As Byte() = ByteConverter.GetBytes("Data to Encrypt")
            Dim encryptedData() As Byte
            Dim decryptedData() As Byte

            'Create a new instance of RSACryptoServiceProvider to generate
            'public and private key data.  Pass an integer specifying a key-
            'length of 2048.
            Dim RSAalg As New RSACryptoServiceProvider(2048)

            'Display the key-legth to the console.
            Console.WriteLine("A new key pair of legth {0} was created", RSAalg.KeySize)

            'Pass the data to ENCRYPT, the public key information 
            '(using RSACryptoServiceProvider.ExportParameters(false),
            'and a boolean flag specifying no OAEP padding.
            encryptedData = RSAEncrypt(dataToEncrypt, RSAalg.ExportParameters(False), False)

            'Pass the data to DECRYPT, the private key information 
            '(using RSACryptoServiceProvider.ExportParameters(true),
            'and a boolean flag specifying no OAEP padding.
            decryptedData = RSADecrypt(encryptedData, RSAalg.ExportParameters(True), False)

            'Display the decrypted plaintext to the console. 
            Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData))
        Catch e As ArgumentNullException
            'Catch this exception in case the encryption did
            'not succeed.
            Console.WriteLine("Encryption failed.")
        End Try
    End Sub 'Main


    Function RSAEncrypt(ByVal DataToEncrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            'Create a new instance of RSACryptoServiceProvider.
            Dim RSAalg As New RSACryptoServiceProvider

            'Import the RSA Key information. This only needs
            'toinclude the public key information.
            RSAalg.ImportParameters(RSAKeyInfo)

            'Encrypt the passed byte array and specify OAEP padding.  
            'OAEP padding is only available on Microsoft Windows XP or
            'later.  
            Return RSAalg.Encrypt(DataToEncrypt, DoOAEPPadding)
            'Catch and display a CryptographicException  
            'to the console.
        Catch e As CryptographicException
            Console.WriteLine(e.Message)

            Return Nothing
        End Try
    End Function 


    Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            'Create a new instance of RSACryptoServiceProvider.
            Dim RSAalg As New RSACryptoServiceProvider

            'Import the RSA Key information. This needs
            'to include the private key information.
            RSAalg.ImportParameters(RSAKeyInfo)

            'Decrypt the passed byte array and specify OAEP padding.  
            'OAEP padding is only available on Microsoft Windows XP or
            'later.  
            Return RSAalg.Decrypt(DataToDecrypt, DoOAEPPadding)
            'Catch and display a CryptographicException  
            'to the console.
        Catch e As CryptographicException
            Console.WriteLine(e.ToString())

            Return Nothing
        End Try
    End Function  

End Module
'</SNIPPET1>