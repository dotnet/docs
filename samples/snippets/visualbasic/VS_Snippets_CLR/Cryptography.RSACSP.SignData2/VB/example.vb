'<SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text

Module RSACSPExample

    Sub Main()
        Try
            ' Create a UnicodeEncoder to convert between byte array and string.
            Dim ByteConverter As New ASCIIEncoding

            Dim dataString As String = "Data to Sign"

            ' Create byte arrays to hold original, encrypted, and decrypted data.
            Dim originalData As Byte() = ByteConverter.GetBytes(dataString)
            Dim signedData() As Byte

            ' Create a new instance of the RSACryptoServiceProvider class 
            ' and automatically create a new key-pair.
            Dim RSAalg As New RSACryptoServiceProvider

            ' Export the key information to an RSAParameters object.
            ' You must pass true to export the private key for signing.
            ' However, you do not need to export the private key
            ' for verification.
            Dim Key As RSAParameters = RSAalg.ExportParameters(True)

            ' Hash and sign the data.
            signedData = HashAndSignBytes(originalData, Key)

            ' Verify the data and display the result to the 
            ' console.
            If VerifySignedHash(originalData, signedData, Key) Then
                Console.WriteLine("The data was verified.")
            Else
                Console.WriteLine("The data does not match the signature.")
            End If

        Catch e As ArgumentNullException
            Console.WriteLine("The data was not signed or verified.")
        End Try
    End Sub

    Function HashAndSignBytes(ByVal DataToSign() As Byte, ByVal Key As RSAParameters) As Byte()
        Try
            ' Create a new instance of RSACryptoServiceProvider using the 
            ' key from RSAParameters.  
            Dim RSAalg As New RSACryptoServiceProvider

            RSAalg.ImportParameters(Key)

            ' Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
            ' to specify the use of SHA1 for hashing.
            Return RSAalg.SignData(DataToSign, New SHA1CryptoServiceProvider)
        Catch e As CryptographicException
            Console.WriteLine(e.Message)

            Return Nothing
        End Try
    End Function


    Function VerifySignedHash(ByVal DataToVerify() As Byte, ByVal SignedData() As Byte, ByVal Key As RSAParameters) As Boolean
        Try
            ' Create a new instance of RSACryptoServiceProvider using the 
            ' key from RSAParameters.
            Dim RSAalg As New RSACryptoServiceProvider

            RSAalg.ImportParameters(Key)

            ' Verify the data using the signature.  Pass a new instance of SHA1CryptoServiceProvider
            ' to specify the use of SHA1 for hashing.
            Return RSAalg.VerifyData(DataToVerify, New SHA1CryptoServiceProvider, SignedData)

        Catch e As CryptographicException
            Console.WriteLine(e.Message)

            Return False
        End Try
    End Function
End Module
'</SNIPPET1>