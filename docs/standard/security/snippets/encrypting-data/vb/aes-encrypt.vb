Imports System
Imports System.IO
Imports System.Security.Cryptography

Module Module1
    Sub Main()
        Try
            Dim keyHex As String

            ' Create a file stream
            Using fileStream As New FileStream("TestData.txt", FileMode.Create)

                ' Create a new instance of the default Aes implementation class  
                ' and configure encryption key.
                Using aes As Aes = Aes.Create()
                    ' Generate a cryptographically secure random key.
                    ' In production, use a key management system or derive from a
                    ' password using Rfc2898DeriveBytes.Pbkdf2 with a high iteration count.
                    aes.GenerateKey()
                    keyHex = Convert.ToHexString(aes.Key)

                    ' Stores IV at the beginning of the file.
                    ' This information will be used for decryption.
                    Dim iv As Byte() = aes.IV
                    fileStream.Write(iv, 0, iv.Length)

                    ' Create a CryptoStream, pass it the FileStream, and encrypt
                    ' it with the Aes class.
                    Using cryptoStream As New CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write)

                        ' By default, the StreamWriter uses UTF-8 encoding.
                        ' To change the text encoding, pass the desired encoding as the second parameter.
                        ' For example, New StreamWriter(cryptoStream, Encoding.Unicode).
                        Using sWriter As New StreamWriter(cryptoStream)

                            'Write to the stream.
                            sWriter.WriteLine("Hello World!")
                        End Using
                    End Using
                End Using
            End Using

            Console.WriteLine("The text was encrypted.")
            Console.WriteLine($"Key (hex): {keyHex}")
        Catch
            Console.WriteLine("The encryption failed.")
            Throw
        End Try
    End Sub
End Module
