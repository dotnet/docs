'<SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text

Module RSACSPExample

    Sub Main()
        Try
            Dim KeyContainerName As String = "MyKeyContainer"

            'Create a new key and persist it in 
            'the key container.
            RSAPersistKeyInCSP(KeyContainerName)

            'Create a UnicodeEncoder to convert between byte array and string.
            Dim ByteConverter As New UnicodeEncoding

            'Create byte arrays to hold original, encrypted, and decrypted data.
            Dim dataToEncrypt As Byte() = ByteConverter.GetBytes("Data to Encrypt")
            Dim encryptedData() As Byte
            Dim decryptedData() As Byte

            'Pass the data to ENCRYPT, the name of the key container, 
            'and a boolean flag specifying no OAEP padding.
            encryptedData = RSAEncrypt(dataToEncrypt, KeyContainerName, False)

            'Pass the data to DECRYPT, the name of the key container, 
            'and a boolean flag specifying no OAEP padding.
            decryptedData = RSADecrypt(encryptedData, KeyContainerName, False)

            'Display the decrypted plaintext to the console. 
            Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData))

            RSADeleteKeyInCSP(KeyContainerName)
        Catch e As ArgumentNullException
            'Catch this exception in case the encryption did
            'not succeed.
            Console.WriteLine("Encryption failed.")
        End Try
    End Sub


    Sub RSAPersistKeyInCSP(ByVal ContainerName As String)
        Try
            ' Create a new instance of CspParameters.  Pass
            ' 13 to specify a DSA container or 1 to specify
            ' an RSA container.  The default is 1.
            Dim cspParams As New CspParameters

            ' Specify the container name using the passed variable.
            cspParams.KeyContainerName = ContainerName

            'Create a new instance of RSACryptoServiceProvider to generate
            'a new key pair.  Pass the CspParameters class to persist the 
            'key in the container.
            Dim RSAalg As New RSACryptoServiceProvider(2048, cspParams)

            'Indicate that the key was persisted.
            Console.WriteLine("The RSA key with a key-size of {0} was persisted in the container, ""{1}"".", _
                              RSAalg.KeySize, ContainerName)
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Sub RSADeleteKeyInCSP(ByVal ContainerName As String)
        Try
            ' Create a new instance of CspParameters.  Pass
            ' 13 to specify a DSA container or 1 to specify
            ' an RSA container.  The default is 1.
            Dim cspParams As New CspParameters

            ' Specify the container name using the passed variable.
            cspParams.KeyContainerName = ContainerName

            'Create a new instance of RSACryptoServiceProvider. 
            'Pass the CspParameters class to use the 
            'key in the container.
            Dim RSAalg As New RSACryptoServiceProvider(cspParams)

            'Delete the key entry in the container.
            RSAalg.PersistKeyInCsp = False

            'Call Clear to release resources and delete the key from the container.
            RSAalg.Clear()

            'Indicate that the key was persisted.
            Console.WriteLine("The RSA key was deleted from the container, ""{0}"".", ContainerName)
        Catch e As CryptographicException
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Function RSAEncrypt(ByVal DataToEncrypt() As Byte, ByVal ContainerName As String, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            ' Create a new instance of CspParameters.  Pass
            ' 13 to specify a DSA container or 1 to specify
            ' an RSA container.  The default is 1.
            Dim cspParams As New CspParameters

            ' Specify the container name using the passed variable.
            cspParams.KeyContainerName = ContainerName

            'Create a new instance of RSACryptoServiceProvider.
            'Pass the CspParameters class to use the key 
            'from the key in the container.
            Dim RSAalg As New RSACryptoServiceProvider(cspParams)

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


    Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal ContainerName As String, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            ' Create a new instance of CspParameters.  Pass
            ' 13 to specify a DSA container or 1 to specify
            ' an RSA container.  The default is 1.
            Dim cspParams As New CspParameters

            ' Specify the container name using the passed variable.
            cspParams.KeyContainerName = ContainerName

            'Create a new instance of RSACryptoServiceProvider.
            'Pass the CspParameters class to use the key 
            'from the key in the container.
            Dim RSAalg As New RSACryptoServiceProvider(cspParams)

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