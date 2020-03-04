' NclSslClientSync
'<snippet0>
Imports System.Collections
Imports System.Net
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Security.Authentication
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.IO

Namespace Examples.System.Net

    Public Class SslTcpClient
        
'       <snippet1>
        ' The following method is invoked by the RemoteCertificateValidationDelegate.
        Public Shared Function ValidateServerCertificate(
            sender As Object, 
            certificate As X509Certificate, 
            chain As X509Chain, 
            sslPolicyErrors As SslPolicyErrors) As Boolean
            
            If sslPolicyErrors = SslPolicyErrors.None Then Return True

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors)

            ' Do not allow this client to communicate with unauthenticated servers.
            Return False
        End Function
        '</snippet1>
        '<snippet3>
        Public Shared Sub RunClient(machineName As String, serverName As String)

            '<snippet5>
            '<snippet4>
            ' Create a TCP/IP client socket.
            ' machineName is the host running the server application.
            Dim client = New TcpClient(machineName, 443)
            Console.WriteLine("Client connected.")

            ' Create an SSL stream that will close the client's stream.
            Dim sslStream = New SslStream(
                client.GetStream(), False, 
                New RemoteCertificateValidationCallback(AddressOf ValidateServerCertificate), Nothing)

            ' The server name must match the name on the server certificate.
            Try
                sslStream.AuthenticateAsClient(serverName)
            Catch e As AuthenticationException
                Console.WriteLine("Exception: {0}", e.Message)

                If e.InnerException IsNot Nothing Then
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message)
                End If

                Console.WriteLine("Authentication failed - closing the connection.")
                client.Close()
                Return
            End Try
            
            ' </snippet4>
            ' Encode a test message into a byte array.
            ' Signal the end of the message using the "<EOF>".
            Dim messsage As Byte() = Encoding.UTF8.GetBytes("Hello from the client.<EOF>")
            
            ' Send hello message to the server.
            sslStream.Write(messsage)
            sslStream.Flush()
            ' </snippet5>
            ' Read message from the server.
            Dim serverMessage = ReadMessage(sslStream)
            Console.WriteLine("Server says: {0}", serverMessage)

            ' Close the client connection
            client.Close()
            Console.WriteLine("Client closed.")
        End Sub
        '</snippet3>
        
        '<snippet6>
        Private Shared Function ReadMessage(sslStream As SslStream) As String

            ' Read the  message sent by the server.
            ' The end of the message is signaled using the "<EOF>" marker.
            Dim buffer = New Byte(2048) {}
            Dim messageData = New StringBuilder()
            Dim bytes As Integer

            Do
                bytes = sslStream.Read(buffer, 0, buffer.Length)

                ' Use Decoder class to convert from bytes to UTF8
                ' in case a character spans two buffers.        
                Dim decoder As Decoder = Encoding.UTF8.GetDecoder()
                Dim chars = New Char(decoder.GetCharCount(buffer, 0, bytes) - 1) {}
                decoder.GetChars(buffer, 0, bytes, chars, 0)
                messageData.Append(chars)

                ' Check for EOF.
                If messageData.ToString().IndexOf("<EOF>") <> -1 Then Exit Do
                
            Loop While bytes <> 0

            Return messageData.ToString()

        End Function
        '</snippet6>

        Private Shared Sub DisplayUsage()

            Console.WriteLine("To start the client specify:")
            Console.WriteLine("clientSync machineName [serverName]")
            Environment.[Exit](1)

        End Sub

        Public Shared Function Main(args As String()) As Integer

            Dim serverCertificateName As String
            Dim machineName As String

            If args Is Nothing OrElse args.Length < 1 Then
                DisplayUsage()
            End If

            ' User can specify the machine name and server name.
            ' Server name must match the name on the server's certificate. 
            machineName = args(0)

            If args.Length < 2 Then
                serverCertificateName = machineName
            Else
                serverCertificateName = args(1)
            End If

            SslTcpClient.RunClient(machineName, serverCertificateName)

            Return 0

        End Function

    End Class

End Namespace
'</snippet0>
