 ' <SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module TripleDESPSample

    Sub Main()
        Try
            ' Create a new TripleDES object to generate a key
            ' and initialization vector (IV).
            Using TripleDESalg As TripleDES = TripleDES.Create

                ' Create a string to encrypt.
                Dim sData As String = "Here is some data to encrypt."

                ' Encrypt the string to an in-memory buffer.
                Dim Data As Byte() = EncryptTextToMemory(sData, TripleDESalg.Key, TripleDESalg.IV)

                ' Decrypt the buffer back to a string.
                Dim Final As String = DecryptTextFromMemory(Data, TripleDESalg.Key, TripleDESalg.IV)

                ' Display the decrypted string to the console.
                Console.WriteLine(Final)
            End Using

        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Function EncryptTextToMemory(ByVal Data As String, ByVal Key() As Byte, ByVal IV() As Byte) As Byte()
        Try
            Dim ret As Byte()
            ' Create a MemoryStream.
            Using mStream As New MemoryStream

                ' Create a new TripleDES object.
                Using tripleDESalg As TripleDES = TripleDES.Create

                    ' Create a CryptoStream using the MemoryStream 
                    ' and the passed key and initialization vector (IV).
                    Using cStream As New CryptoStream(mStream, _
                        tripleDESalg.CreateEncryptor(Key, IV), CryptoStreamMode.Write)

                        ' Convert the passed string to a byte array.
                        Dim toEncrypt As Byte() = New ASCIIEncoding().GetBytes(Data)

                        ' Write the byte array to the crypto stream and flush it.
                        cStream.Write(toEncrypt, 0, toEncrypt.Length)
                        cStream.FlushFinalBlock()

                        ' Get an array of bytes from the 
                        ' MemoryStream that holds the 
                        ' encrypted data.
                        ret = mStream.ToArray()
                    End Using
                End Using
            End Using

            ' Return the encrypted buffer.
            Return ret
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function


    Function DecryptTextFromMemory(ByVal Data() As Byte, ByVal Key() As Byte, ByVal IV() As Byte) As String
        Try
            Dim ret As String
            ' Create a new MemoryStream using the passed 
            ' array of encrypted data.
            Using msDecrypt As New MemoryStream(Data)

                ' Create a new TripleDES object.
                Using tripleDESalg As TripleDES = TripleDES.Create

                    ' Create a CryptoStream using the MemoryStream 
                    ' and the passed key and initialization vector (IV).
                    Using csDecrypt As New CryptoStream(msDecrypt, _
                         tripleDESalg.CreateDecryptor(Key, IV), CryptoStreamMode.Read)

                        ' Create buffer to hold the decrypted data.
                        Dim fromEncrypt(Data.Length - 1) As Byte

                        ' Read the decrypted data out of the crypto stream
                        ' and place it into the temporary buffer.
                        csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

                        'Convert the buffer into a string and return it.
                        ret = New ASCIIEncoding().GetString(fromEncrypt)
                    End Using
                End Using
            End Using
            Return ret

        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function
End Module
' </SNIPPET1>