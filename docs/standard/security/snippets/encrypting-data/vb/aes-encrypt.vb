Imports System
Imports System.IO
Imports System.Security.Cryptography

Module Module1
    Sub Main()
        Try
            Dim myStream As FileStream = New FileStream("TestData.txt", FileMode.OpenOrCreate)

            'Create a new instance of the default Aes implementation class  
            'and encrypt the stream.  
            Dim aes As Aes = Aes.Create()

            Dim key As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
            Dim iv As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

            'Create a CryptoStream, pass it the FileStream, and encrypt
            'it with the Aes class.  
            Dim cryptStream As New CryptoStream(
                myStream,
                aes.CreateEncryptor(key, iv),
                CryptoStreamMode.Write)

            'Create a StreamWriter for easy writing to the
            'file stream.  
            Dim sWriter As New StreamWriter(cryptStream)

            'Write to the stream.  
            sWriter.WriteLine("Hello World!")

            'Close all the connections.  
            sWriter.Close()
            cryptStream.Close()
            myStream.Close()

            'Inform the user that the message was written  
            'to the stream.  
            Console.WriteLine("The text was encrypted.")
        Catch
            'Inform the user that an exception was raised.  
            Console.WriteLine("The encryption failed.")
            Throw
        End Try
    End Sub
End Module
