' <SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module DESPSample

    Sub Main()
        Try
            ' Create a new DES object to generate a key 
            ' and initialization vector (IV).  Specify one 
            ' of the recognized simple names for this 
            ' algorithm.
            Dim DESalg As DES = DES.Create("DES")

            ' Create a string to encrypt.
            Dim sData As String = "Here is some data to encrypt."

            ' Encrypt the string to an in-memory buffer.
            Dim Data As Byte() = EncryptTextToMemory(sData, DESalg.Key, DESalg.IV)

            ' Decrypt the buffer back to a string.
            Dim Final As String = DecryptTextFromMemory(Data, DESalg.Key, DESalg.IV)

            ' Display the decrypted string to the console.
            Console.WriteLine(Final)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Function EncryptTextToMemory(ByVal Data As String, ByVal Key() As Byte, ByVal IV() As Byte) As Byte()
        Try
            ' Create a MemoryStream.
            Dim mStream As New MemoryStream

            ' Create a new DES object.
            Dim DESalg As DES = DES.Create

            ' Create a CryptoStream using the MemoryStream 
            ' and the passed key and initialization vector (IV).
            Dim cStream As New CryptoStream(mStream, _
                                            DESalg.CreateEncryptor(Key, IV), _
                                            CryptoStreamMode.Write)

            ' Convert the passed string to a byte array.
            Dim toEncrypt As Byte() = New ASCIIEncoding().GetBytes(Data)

            ' Write the byte array to the crypto stream and flush it.
            cStream.Write(toEncrypt, 0, toEncrypt.Length)
            cStream.FlushFinalBlock()

            ' Get an array of bytes from the 
            ' MemoryStream that holds the 
            ' encrypted data.
            Dim ret As Byte() = mStream.ToArray()

            ' Close the streams.
            cStream.Close()
            mStream.Close()

            ' Return the encrypted buffer.
            Return ret
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function


    Function DecryptTextFromMemory(ByVal Data() As Byte, ByVal Key() As Byte, ByVal IV() As Byte) As String
        Try
            ' Create a new MemoryStream using the passed 
            ' array of encrypted data.
            Dim msDecrypt As New MemoryStream(Data)

            ' Create a new DES object.
            Dim DESalg As DES = DES.Create

            ' Create a CryptoStream using the MemoryStream 
            ' and the passed key and initialization vector (IV).
            Dim csDecrypt As New CryptoStream(msDecrypt, _
                                              DESalg.CreateDecryptor(Key, IV), _
                                              CryptoStreamMode.Read)

            ' Create buffer to hold the decrypted data.
            Dim fromEncrypt(Data.Length) As Byte

            ' Read the decrypted data out of the crypto stream
            ' and place it into the temporary buffer.
            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length)

            'Convert the buffer into a string and return it.
            Return New ASCIIEncoding().GetString(fromEncrypt)
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function
End Module
' </SNIPPET1>