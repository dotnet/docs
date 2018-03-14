' <snippet1>
Imports System
Imports System.Security.Cryptography
Imports System.Text

 _

Class RSACSPSample


    Shared Sub Main()
        Try
            'Create a UnicodeEncoder to convert between byte array and string.
            Dim ByteConverter As New UnicodeEncoding()

            'Create byte arrays to hold original, encrypted, and decrypted data.
            Dim dataToEncrypt As Byte() = ByteConverter.GetBytes("Data to Encrypt")
            Dim encryptedData() As Byte
            Dim decryptedData() As Byte

            'Create a new instance of RSACryptoServiceProvider to generate
            'public and private key data.
            Using RSA As New RSACryptoServiceProvider

                'Pass the data to ENCRYPT, the public key information 
                '(using RSACryptoServiceProvider.ExportParameters(false),
                'and a boolean flag specifying no OAEP padding.
                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(False), False)

                'Pass the data to DECRYPT, the private key information 
                '(using RSACryptoServiceProvider.ExportParameters(true),
                'and a boolean flag specifying no OAEP padding.
                decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(True), False)

                'Display the decrypted plaintext to the console. 
                Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData))
            End Using
        Catch e As ArgumentNullException
            'Catch this exception in case the encryption did
            'not succeed.
            Console.WriteLine("Encryption failed.")
        End Try
    End Sub


    Public Shared Function RSAEncrypt(ByVal DataToEncrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim encryptedData() As Byte
            'Create a new instance of RSACryptoServiceProvider.
            Using RSA As New RSACryptoServiceProvider

                'Import the RSA Key information. This only needs
                'toinclude the public key information.
                RSA.ImportParameters(RSAKeyInfo)

                'Encrypt the passed byte array and specify OAEP padding.  
                'OAEP padding is only available on Microsoft Windows XP or
                'later.  
                encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding)
            End Using
            Return encryptedData
            'Catch and display a CryptographicException  
            'to the console.
        Catch e As CryptographicException
            Console.WriteLine(e.Message)

            Return Nothing
        End Try
    End Function


    Public Shared Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim decryptedData() As Byte
            'Create a new instance of RSACryptoServiceProvider.
            Using RSA As New RSACryptoServiceProvider
                'Import the RSA Key information. This needs
                'to include the private key information.
                RSA.ImportParameters(RSAKeyInfo)

                'Decrypt the passed byte array and specify OAEP padding.  
                'OAEP padding is only available on Microsoft Windows XP or
                'later.  
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding)
                'Catch and display a CryptographicException  
                'to the console.
            End Using
            Return decryptedData
        Catch e As CryptographicException
            Console.WriteLine(e.ToString())

            Return Nothing
        End Try
    End Function
End Class
' </snippet1>