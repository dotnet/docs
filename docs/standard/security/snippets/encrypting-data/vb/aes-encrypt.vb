Imports System
Imports System.IO
Imports System.Security.Cryptography

Module Module1
    Sub Main()
        Try
            ' Create a file stream
            Using fileStream As New FileStream("TestData.txt", FileMode.OpenOrCreate)

                ' Create a new instance of the default Aes implementation class  
                ' and configure encryption key.
                Using aes As Aes = Aes.Create()
                    ' This key is for illustration purposes only.
                    ' In production, use a securely stored or managed key.
                    Dim key As Byte() = {
                        &H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8,
                        &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16
                    }

                    aes.Key = key

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

            Console.WriteLine("The file was encrypted.")
        Catch
            Console.WriteLine("The encryption failed.")
            Throw
        End Try
    End Sub
End Module
