'<SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module RSACSPExample

    Sub Main()
        Try
            Dim ByteConverter As New ASCIIEncoding

            ' Create some bytes to be signed.
            Dim dataBytes As Byte() = ByteConverter.GetBytes("Here is some data to sign!")

            ' Create a buffer for the memory stream.
            ' VB automatically pads arrays with an extra 
            ' Digit of "0".
            ' RSACryptoServiceProvider will not verify
            ' the buffer if the automatic padding is 
            ' present.  To remove the padding, decrement
            ' the buffer length by 1.
            Dim buffer(dataBytes.Length - 1) As Byte

            ' Create a MemoryStream.
            Dim mStream As New MemoryStream(buffer)

            ' Write the bytes to the stream and flush it.
            mStream.Write(dataBytes, 0, dataBytes.Length)

            mStream.Flush()

            ' Create a new instance of the RSACryptoServiceProvider class 
            ' and automatically create a new key-pair.
            Dim RSAalg As New RSACryptoServiceProvider

            ' Export the key information to an RSAParameters object.
            ' You must pass true to export the private key for signing.
            ' However, you do not need to export the private key
            ' for verification.
            Dim Key As RSAParameters = RSAalg.ExportParameters(True)

            ' Hash and sign the data.
            Dim signedData As Byte() = HashAndSignBytes(mStream, Key)


            ' Verify the data and display the result to the 
            ' console.
            If VerifySignedHash(dataBytes, signedData, Key) Then
                Console.WriteLine("The data was verified.")
            Else
                Console.WriteLine("The data does not match the signature.")
            End If

            ' Close the MemoryStream.
            mStream.Close()

        Catch e As ArgumentNullException
            Console.WriteLine("The data was not signed or verified")
        End Try
    End Sub 

    Function HashAndSignBytes(ByVal DataStream As Stream, ByVal Key As RSAParameters) As Byte()
        Try
            ' Reset the current position in the stream to 
            ' the beginning of the stream (0). RSACryptoServiceProvider
            ' can't verify the data unless the the stream position
            ' is set to the starting position of the data.
            DataStream.Position = 0

            ' Create a new instance of RSACryptoServiceProvider using the 
            ' key from RSAParameters.  
            Dim RSAalg As New RSACryptoServiceProvider

            RSAalg.ImportParameters(Key)

            ' Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
            ' to specify the use of SHA1 for hashing.
            Return RSAalg.SignData(DataStream, New SHA1CryptoServiceProvider)
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