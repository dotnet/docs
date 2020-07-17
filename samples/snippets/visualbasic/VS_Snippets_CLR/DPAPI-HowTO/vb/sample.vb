' <snippet1>
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography



Public Module MemoryProtectionSample

    Sub Main()
        Run()

    End Sub


    Sub Run()
        Try

            ''''''''''''''''''''''''''''''''''''
            '
            ' Memory Encryption - ProtectedMemory
            '
            ''''''''''''''''''''''''''''''''''''
            ' Create the original data to be encrypted (The data length should be a multiple of 16).
            Dim toEncrypt As Byte() = UnicodeEncoding.ASCII.GetBytes("ThisIsSomeData16")

            Console.WriteLine("Original data: " + UnicodeEncoding.ASCII.GetString(toEncrypt))
            Console.WriteLine("Encrypting...")

            ' Encrypt the data in memory.
            EncryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon)

            Console.WriteLine("Encrypted data: " + UnicodeEncoding.ASCII.GetString(toEncrypt))
            Console.WriteLine("Decrypting...")

            ' Decrypt the data in memory.
            DecryptInMemoryData(toEncrypt, MemoryProtectionScope.SameLogon)

            Console.WriteLine("Decrypted data: " + UnicodeEncoding.ASCII.GetString(toEncrypt))


            ''''''''''''''''''''''''''''''''''''
            '
            ' Data Encryption - ProtectedData
            '
            ''''''''''''''''''''''''''''''''''''
            ' Create the original data to be encrypted
            toEncrypt = UnicodeEncoding.ASCII.GetBytes("This is some data of any length.")

            ' Create a file.
            Dim fStream As New FileStream("Data.dat", FileMode.OpenOrCreate)

            ' Create some random entropy.
            Dim entropy As Byte() = CreateRandomEntropy()

            Console.WriteLine()
            Console.WriteLine("Original data: " + UnicodeEncoding.ASCII.GetString(toEncrypt))
            Console.WriteLine("Encrypting and writing to disk...")

            ' Encrypt a copy of the data to the stream.
            Dim bytesWritten As Integer = EncryptDataToStream(toEncrypt, entropy, DataProtectionScope.CurrentUser, fStream)

            fStream.Close()

            Console.WriteLine("Reading data from disk and decrypting...")

            ' Open the file.
            fStream = New FileStream("Data.dat", FileMode.Open)

            ' Read from the stream and decrypt the data.
            Dim decryptData As Byte() = DecryptDataFromStream(entropy, DataProtectionScope.CurrentUser, fStream, bytesWritten)

            fStream.Close()

            Console.WriteLine("Decrypted data: " + UnicodeEncoding.ASCII.GetString(decryptData))


        Catch e As Exception
            Console.WriteLine("ERROR: " + e.Message)
        End Try

    End Sub



    Sub EncryptInMemoryData(ByVal Buffer() As Byte, ByVal Scope As MemoryProtectionScope)
        If Buffer Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If
        If Buffer.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If

        ' Encrypt the data in memory. The result is stored in the same array as the original data.
        ProtectedMemory.Protect(Buffer, Scope)

    End Sub


    Sub DecryptInMemoryData(ByVal Buffer() As Byte, ByVal Scope As MemoryProtectionScope)
        If Buffer Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If
        If Buffer.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If

        ' Decrypt the data in memory. The result is stored in the same array as the original data.
        ProtectedMemory.Unprotect(Buffer, Scope)

    End Sub


    Function CreateRandomEntropy() As Byte()
        ' Create a byte array to hold the random value.
        Dim entropy(15) As Byte

        ' Create a new instance of the RNGCryptoServiceProvider.
        ' Fill the array with a random value.
        Dim RNG As New RNGCryptoServiceProvider()

        RNG.GetBytes(entropy)

        ' Return the array.
        Return entropy

    End Function 'CreateRandomEntropy



    Function EncryptDataToStream(ByVal Buffer() As Byte, ByVal Entropy() As Byte, ByVal Scope As DataProtectionScope, ByVal S As Stream) As Integer
        If Buffer Is Nothing Then
            Throw New ArgumentNullException("Buffer")
        End If
        If Buffer.Length <= 0 Then
            Throw New ArgumentException("Buffer")
        End If
        If Entropy Is Nothing Then
            Throw New ArgumentNullException("Entropy")
        End If
        If Entropy.Length <= 0 Then
            Throw New ArgumentException("Entropy")
        End If
        If S Is Nothing Then
            Throw New ArgumentNullException("S")
        End If
        Dim length As Integer = 0

        ' Encrypt the data and store the result in a new byte array. The original data remains unchanged.
        Dim encryptedData As Byte() = ProtectedData.Protect(Buffer, Entropy, Scope)

        ' Write the encrypted data to a stream.
        If S.CanWrite AndAlso Not (encryptedData Is Nothing) Then
            S.Write(encryptedData, 0, encryptedData.Length)

            length = encryptedData.Length
        End If

        ' Return the length that was written to the stream. 
        Return length

    End Function 'EncryptDataToStream


    Function DecryptDataFromStream(ByVal Entropy() As Byte, ByVal Scope As DataProtectionScope, ByVal S As Stream, ByVal Length As Integer) As Byte()
        If S Is Nothing Then
            Throw New ArgumentNullException("S")
        End If
        If Length <= 0 Then
            Throw New ArgumentException("Length")
        End If
        If Entropy Is Nothing Then
            Throw New ArgumentNullException("Entropy")
        End If
        If Entropy.Length <= 0 Then
            Throw New ArgumentException("Entropy")
        End If


        Dim inBuffer(Length - 1) As Byte
        Dim outBuffer() As Byte

        ' Read the encrypted data from a stream.
        If S.CanRead Then
            S.Read(inBuffer, 0, Length)

            outBuffer = ProtectedData.Unprotect(inBuffer, Entropy, Scope)
        Else
            Throw New IOException("Could not read the stream.")
        End If

        ' Return the unencrypted data as byte array. 
        Return outBuffer

    End Function 'DecryptDataFromStream 
End Module 'MemoryProtectionSample
' </snippet1>
