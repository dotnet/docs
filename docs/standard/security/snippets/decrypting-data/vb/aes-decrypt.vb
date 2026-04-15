Imports System
Imports System.IO
Imports System.Security.Cryptography

Module Module1
    Sub Main()
        ' The key must match the key used during encryption.
        ' In production, retrieve the key from a secure key management
        ' system rather than hardcoding it in source code.
        Dim key As Byte() = Convert.FromHexString(Environment.GetCommandLineArgs()(1))

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

                    Using cryptoStream As New CryptoStream(fileStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read)

                        ' By default, the StreamReader uses UTF-8 encoding.
                        ' To change the text encoding, pass the desired encoding as the second parameter.
                        ' For example, New StreamReader(cryptoStream, Encoding.Unicode).
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
