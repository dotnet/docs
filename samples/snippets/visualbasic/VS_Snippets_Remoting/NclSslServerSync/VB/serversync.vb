' NclSslServerSync

' <snippet0>
Imports System.Collections
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.Security
Imports System.Security.Authentication
Imports System.Text
Imports System.Security.Cryptography.X509Certificates
Imports System.IO

Namespace Examples.System.Net
    Public NotInheritable Class SslTcpServer
        Shared serverCertificate As X509Certificate = Nothing

        ' The certificate parameter specifies the name of the file 
        ' containing the machine certificate.
        Public Shared Sub RunServer(certificate As String)
            serverCertificate = X509Certificate.CreateFromCertFile(certificate)
            ' Create a TCP/IP (IPv4) socket And listen for incoming connections.
            Dim listener = New TcpListener(IPAddress.Any, 8080)
            listener.Start()

            While True
                Console.WriteLine("Waiting for a client to connect...")
                ' Application blocks while waiting for an incoming connection.
                ' Type CNTL-C to terminate the server.
                Dim client As TcpClient = listener.AcceptTcpClient()
                ProcessClient(client)
            End While
        End Sub
        '<snippet1>
        Private Shared Sub ProcessClient(client As TcpClient)
            ' A client has connected. Create the 
            ' SslStream using the client's network stream.
            Dim sslStream = New SslStream(client.GetStream(), False)

            Try

                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired:=False, checkCertificateRevocation:=True)
                ' Display the properties And settings for the authenticated stream.
                DisplaySecurityLevel(sslStream)
                DisplaySecurityServices(sslStream)
                DisplayCertificateInformation(sslStream)
                DisplayStreamProperties(sslStream)

                ' Set timeouts for the read and write to 5 seconds.
                sslStream.ReadTimeout = 5000
                sslStream.WriteTimeout = 5000

                ' Read a message from the client.   
                Console.WriteLine("Waiting for client message...")
                Dim messageData As String = ReadMessage(sslStream)
                Console.WriteLine("Received: {0}", messageData)

                ' Write a message to the client.
                Dim message As Byte() = Encoding.UTF8.GetBytes("Hello from the server.<EOF>")
                Console.WriteLine("Sending hello message.")
                sslStream.Write(message)
            Catch e As AuthenticationException
                Console.WriteLine("Exception: {0}", e.Message)

                If e.InnerException IsNot Nothing Then
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message)
                End If

                Console.WriteLine("Authentication failed - closing the connection.")
                sslStream.Close()
                client.Close()
                Return
            Finally
                ' The client stream will be closed with the sslStream
                ' because we specified this behavior when creating
                ' the sslStream.
                sslStream.Close()
                client.Close()
            End Try
        End Sub

        '</snippet1>
        '<snippet2>
        Private Shared Function ReadMessage(sslStream As SslStream) As String

            ' Read the  message sent by the client.
            ' The client signals the end of the message using the
            ' "<EOF>" marker.
            Dim buffer As Byte() = New Byte(2048) {}
            Dim messageData As StringBuilder = New StringBuilder()
            Dim bytes As Integer = -1

            Do
                ' Read the client's test message.
                bytes = sslStream.Read(buffer, 0, buffer.Length)

                ' Use decoder class to convert from bytes to UTF8
                ' in case a character spans two buffers.
                Dim decoder As Decoder = Encoding.UTF8.GetDecoder()
                Dim chars As Char() = New Char(decoder.GetCharCount(buffer, 0, bytes) - 1) {}
                decoder.GetChars(buffer, 0, bytes, chars, 0)
                messageData.Append(chars)

                ' Check for EOF or an empty message.
                If messageData.ToString().IndexOf("<EOF>") <> -1 Then
                    Exit Do
                End If
            Loop While bytes <> 0

            Return messageData.ToString()
        End Function
        ' </snippet2>

        ' <snippet3>
        Private Shared Sub DisplaySecurityLevel(stream As SslStream)
            Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, stream.CipherStrength)
            Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, stream.HashStrength)
            Console.WriteLine("Key exchange: {0} strength {1}", stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength)
            Console.WriteLine("Protocol: {0}", stream.SslProtocol)
        End Sub
        '</snippet3>

        '<snippet4>
        Private Shared Sub DisplaySecurityServices(stream As SslStream)
            Console.WriteLine("Is authenticated: {0} as server? {1}", stream.IsAuthenticated, stream.IsServer)
            Console.WriteLine("IsSigned: {0}", stream.IsSigned)
            Console.WriteLine("Is Encrypted: {0}", stream.IsEncrypted)
        End Sub
        ' </snippet4>

        ' <snippet5>
        Private Shared Sub DisplayStreamProperties(stream As SslStream)
            Console.WriteLine("Can read: {0}, write {1}", stream.CanRead, stream.CanWrite)
            Console.WriteLine("Can timeout: {0}", stream.CanTimeout)
        End Sub
        ' </snippet5>

        ' <snippet6>
        Private Shared Sub DisplayCertificateInformation(stream As SslStream)
            Console.WriteLine("Certificate revocation list checked: {0}", stream.CheckCertRevocationStatus)
            Dim localCertificate As X509Certificate = stream.LocalCertificate

            If stream.LocalCertificate IsNot Nothing Then
                Console.WriteLine("Local cert was issued to {0} and is valid from {1} until {2}.", localCertificate.Subject, localCertificate.GetEffectiveDateString(), localCertificate.GetExpirationDateString())
            Else
                Console.WriteLine("Local certificate is null.")
            End If

            ' Display the properties of the client's certificate.
            Dim remoteCertificate As X509Certificate = stream.RemoteCertificate

            If stream.RemoteCertificate IsNot Nothing Then
                Console.WriteLine("Remote cert was issued to {0} and is valid from {1} until {2}.", remoteCertificate.Subject, remoteCertificate.GetEffectiveDateString(), remoteCertificate.GetExpirationDateString())
            Else
                Console.WriteLine("Remote certificate is null.")
            End If
        End Sub
        ' </snippet6>

        Private Shared Sub DisplayUsage()
            Console.WriteLine("To start the server specify:")
            Console.WriteLine("serverSync certificateFile.cer")
            Environment.[Exit](1)
        End Sub

        Public Shared Function Main(ByVal args As String()) As Integer
            Dim certificate As String

            If args Is Nothing OrElse args.Length < 1 Then
                DisplayUsage()
            End If

            certificate = args(0)
            RunServer(certificate)
            Return 0
        End Function
    End Class
End Namespace
'</snippet0>
