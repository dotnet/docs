Imports System
Imports System.IO
Imports System.Security.Cryptography

Module Module1
    Sub Main()
        ' Decryption key must be the same value that was used
        ' to encrypt the stream.
        Dim key As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

        Try
            ' Create a file stream.
            Using fileStream As New FileStream("TestData.txt", FileMode.Open)

                ' Create a new instance of the default Aes implementation class
                Using aes As Aes = Aes.Create()

                    ' Reads IV value from beginning of the file.
                    Dim iv As Byte() = New Byte(aes.IV.Length - 1) {}
                    Dim numBytesToRead As Integer = CType(aes.IV.Length, Integer)
                    Dim numBytesRead As Integer = 0

                    While (numBytesToRead > 0)
                        Dim n As Integer = fileStream.Read(iv, numBytesRead, numBytesToRead)
                        If n = 0 Then
                            Exit While
                        End If
                        numBytesRead += n
                        numBytesToRead -= n
                    End While

                    ' Create an instance of the CryptoStream class, pass it the file stream, and decrypt
                    ' it with the Rijndael class using the key and IV.
                    Using cryptoStream As New CryptoStream(fileStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read)

                        ' Read the stream.
                        Using decryptReader As New StreamReader(cryptoStream)

                            ' Display the message.
                            Console.WriteLine($"The decrypted original message: {decryptReader.ReadToEnd()}")
                        End Using
                    End Using
                End Using
            End Using
        Catch
            Console.WriteLine("The decryption Failed.")
            Throw
        End Try
    End Sub
End Module
