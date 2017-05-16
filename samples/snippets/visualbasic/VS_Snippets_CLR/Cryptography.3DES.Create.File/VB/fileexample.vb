' <SNIPPET1>
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Module TripleDESSample

    Sub Main()
        Try
            ' Create a new TripleDES object to generate a key
            ' and initialization vector (IV).
            Using TripleDESalg As TripleDES = TripleDES.Create

                ' Create a string to encrypt.
                Dim sData As String = "Here is some data to encrypt."
                Dim FileName As String = "CText.txt"

                ' Encrypt text to a file using the file name, key, and IV.
                EncryptTextToFile(sData, FileName, TripleDESalg.Key, TripleDESalg.IV)

                ' Decrypt the text from a file using the file name, key, and IV.
                Dim Final As String = DecryptTextFromFile(FileName, TripleDESalg.Key, TripleDESalg.IV)

                ' Display the decrypted string to the console.
                Console.WriteLine(Final)
            End Using
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub


    Sub EncryptTextToFile(ByVal Data As String, ByVal FileName As String,
ByVal Key() As Byte, ByVal IV() As Byte)
        Try
            ' Create or open the specified file.
            Using fStream As FileStream = File.Open(FileName, FileMode.OpenOrCreate)

                ' Create a new TripleDES object.
                Using TripleDESalg As TripleDES = TripleDES.Create

                    ' Create a CryptoStream using the FileStream 
                    ' and the passed key and initialization vector (IV).
                    Using cStream As New CryptoStream(fStream, _
                        TripleDESalg.CreateEncryptor(Key, IV), _
                        CryptoStreamMode.Write)

                        ' Create a StreamWriter using the CryptoStream.
                        Using sWriter As New StreamWriter(cStream)

                            ' Write the data to the stream 
                            ' to encrypt it.
                            sWriter.WriteLine(Data)

                        End Using
                    End Using
                End Using
            End Using


        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
        Catch e As UnauthorizedAccessException
            Console.WriteLine("A file access error occurred: {0}", e.Message)
        End Try
    End Sub


    Function DecryptTextFromFile(ByVal FileName As String, ByVal Key() As Byte, ByVal IV() As Byte) As String
        Try
            Dim retVal As String
            ' Create or open the specified file. 
            Using fStream As FileStream = File.Open(FileName, FileMode.OpenOrCreate)

                ' Create a new TripleDES object.
                Using TripleDESalg As TripleDES = TripleDES.Create

                    ' Create a CryptoStream using the FileStream 
                    ' and the passed key and initialization vector (IV).
                    Using cStream As New CryptoStream(fStream, _
                        TripleDESalg.CreateDecryptor(Key, IV), CryptoStreamMode.Read)

                        ' Create a StreamReader using the CryptoStream.
                        Using sReader As New StreamReader(cStream)

                            ' Read the data from the stream 
                            ' to decrypt it.
                            retVal = sReader.ReadLine()
                        End Using
                    End Using
                End Using
            End Using

            Return retVal
        Catch e As CryptographicException
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
            Return Nothing
        Catch e As UnauthorizedAccessException
            Console.WriteLine("A file access error occurred: {0}", e.Message)
            Return Nothing
        End Try
    End Function
End Module
' </SNIPPET1>