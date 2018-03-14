 ' <SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module TrippleDESCSPSample

    Sub Main()
        Try
            ' Create a new TripleDESCryptoServiceProvider object
            ' to generate a key and initialization vector (IV).
            Dim tDESalg As New TripleDESCryptoServiceProvider

            ' Create a string to encrypt.
            Dim sData As String = "Here is some data to encrypt."
            Dim FileName As String = "CText.txt"

            ' Encrypt text to a file using the file name, key, and IV.
            EncryptTextToFile(sData, FileName, tDESalg.Key, tDESalg.IV)

            ' Decrypt the text from a file using the file name, key, and IV.
            Dim Final As String = DecryptTextFromFile(FileName, tDESalg.Key, tDESalg.IV)

            ' Display the decrypted string to the console.
            Console.WriteLine(Final)
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Sub EncryptTextToFile(ByVal Data As String, ByVal FileName As String, ByVal Key() As Byte, ByVal IV() As Byte)
        Try
            ' Create or open the specified file.
            Dim fStream As FileStream = File.Open(FileName, FileMode.OpenOrCreate)

            ' Create a CryptoStream using the FileStream 
            ' and the passed key and initialization vector (IV).
            Dim cStream As New CryptoStream(fStream, _
                                            New TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV), _
                                            CryptoStreamMode.Write)

            ' Create a StreamWriter using the CryptoStream.
            Dim sWriter As New StreamWriter(cStream)

            ' Write the data to the stream 
            ' to encrypt it.
            sWriter.WriteLine(Data)

            ' Close the streams and
            ' close the file.
            sWriter.Close()
            cStream.Close()
            fStream.Close()
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
        Catch e As UnauthorizedAccessException
            Console.WriteLine("A file error occurred: {0}", e.Message)
        End Try
    End Sub


    Function DecryptTextFromFile(ByVal FileName As String, ByVal Key() As Byte, ByVal IV() As Byte) As String
        Try
            ' Create or open the specified file. 
            Dim fStream As FileStream = File.Open(FileName, FileMode.OpenOrCreate)

            ' Create a CryptoStream using the FileStream 
            ' and the passed key and initialization vector (IV).
            Dim cStream As New CryptoStream(fStream, _
                                            New TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV), _
                                            CryptoStreamMode.Read)

            ' Create a StreamReader using the CryptoStream.
            Dim sReader As New StreamReader(cStream)

            ' Read the data from the stream 
            ' to decrypt it.
            Dim val As String = sReader.ReadLine()

            ' Close the streams and
            ' close the file.
            sReader.Close()
            cStream.Close()
            fStream.Close()

            ' Return the string. 
            Return val
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        Catch e As UnauthorizedAccessException
            Console.WriteLine("A file error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function
End Module
 ' </SNIPPET1>