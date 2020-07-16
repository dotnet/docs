Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Net.Sockets

Module Module1
    Sub Main()
        Try
            'Create a TCP connection to a listening TCP process.  
            'Use "localhost" to specify the current computer or  
            'replace "localhost" with the IP address of the
            'listening process.
            Dim tcp As New TcpClient("localhost", 11000)

            'Create a network stream from the TCP connection.
            Dim netStream As NetworkStream = tcp.GetStream()

            'Create a new instance of the Aes class  
            'and encrypt the stream.  
            Dim aes As Aes = Aes.Create()

            Dim key As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
            Dim iv As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

            'Create a CryptoStream, pass it the NetworkStream, and encrypt
            'it with the Aes class.  
            Dim cryptStream As New CryptoStream(netStream, aes.CreateEncryptor(key, iv), CryptoStreamMode.Write)

            'Create a StreamWriter for easy writing to the
            'network stream.  
            Dim sWriter As New StreamWriter(cryptStream)

            'Write to the stream.  
            sWriter.WriteLine("Hello World!")

            'Inform the user that the message was written  
            'to the stream.  
            Console.WriteLine("The message was sent.")

            'Close all the connections.  
            sWriter.Close()
            cryptStream.Close()
            netStream.Close()
            tcp.Close()
        Catch
            'Inform the user that an exception was raised.  
            Console.WriteLine("The connection failed.")
        End Try
    End Sub
End Module