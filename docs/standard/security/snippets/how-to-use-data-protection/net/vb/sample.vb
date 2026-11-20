Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Module DataProtectionSample

    Sub Main()
        Try
            ' Data Encryption - ProtectedData

            ' Create the original data to be encrypted.
            Dim toEncrypt As Byte() = Encoding.ASCII.GetBytes("This is some data of any length.")

            ' Create some random entropy.
            Dim entropy As Byte() = CreateRandomEntropy()

            Console.WriteLine()
            Console.WriteLine($"Original data: {Encoding.ASCII.GetString(toEncrypt)}")
            Console.WriteLine("Encrypting and writing to disk...")

            Dim bytesWritten As Integer

            ' Encrypt a copy of the data to the stream.
            Using writeStream As New FileStream("Data.dat", FileMode.OpenOrCreate)
                bytesWritten = EncryptDataToStream(toEncrypt, entropy, DataProtectionScope.CurrentUser, writeStream)
            End Using

            Console.WriteLine("Reading data from disk and decrypting...")

            ' Read from the stream and decrypt the data.
            Dim decryptData As Byte()
            Using readStream As New FileStream("Data.dat", FileMode.Open)
                decryptData = DecryptDataFromStream(entropy, DataProtectionScope.CurrentUser, readStream, bytesWritten)
            End Using

            Console.WriteLine($"Decrypted data: {Encoding.ASCII.GetString(decryptData)}")

        Catch e As Exception
            Console.WriteLine($"ERROR: {e.Message}")
        End Try
    End Sub

    Function CreateRandomEntropy() As Byte()
        ' Create a byte array to hold the random value and fill it with a random value.
        Dim entropy(15) As Byte
        RandomNumberGenerator.Fill(entropy)

        Return entropy
    End Function

    Function EncryptDataToStream(buffer As Byte(), entropy As Byte(), scope As DataProtectionScope, stream As Stream) As Integer
        ArgumentNullException.ThrowIfNull(buffer)
        ArgumentOutOfRangeException.ThrowIfZero(buffer.Length, NameOf(buffer))
        ArgumentNullException.ThrowIfNull(entropy)
        ArgumentOutOfRangeException.ThrowIfZero(entropy.Length, NameOf(entropy))
        ArgumentNullException.ThrowIfNull(stream)

        Dim length As Integer = 0

        ' Encrypt the data and store the result in a new byte array. The original data remains unchanged.
        Dim encryptedData As Byte() = ProtectedData.Protect(buffer, entropy, scope)

        ' Write the encrypted data to a stream.
        If stream.CanWrite Then
            stream.Write(encryptedData, 0, encryptedData.Length)
            length = encryptedData.Length
        End If

        ' Return the length that was written to the stream.
        Return length
    End Function

    Function DecryptDataFromStream(entropy As Byte(), scope As DataProtectionScope, stream As Stream, length As Integer) As Byte()
        ArgumentNullException.ThrowIfNull(stream)
        ArgumentOutOfRangeException.ThrowIfZero(length, NameOf(length))
        ArgumentNullException.ThrowIfNull(entropy)
        ArgumentOutOfRangeException.ThrowIfZero(entropy.Length, NameOf(entropy))

        If Not stream.CanRead Then
            Throw New IOException("Could not read the stream.")
        End If

        Dim inBuffer(length - 1) As Byte
        stream.ReadExactly(inBuffer, 0, length)

        ' Return the decrypted data.
        Return ProtectedData.Unprotect(inBuffer, entropy, scope)
    End Function

End Module
