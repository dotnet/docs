Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Security.Authentication
Imports System.Net.Sockets
Imports System.Net.Security
Imports System.Net
Imports System.Collections
Imports System.Threading

' NclSslClientAsync
'<snippet0>
Namespace Examples.Ssl

	' The following example demonstrates the client side of a 
	' client-server application that communicates using the
	' SslStream and TcpClient classes.
	' After connecting to the server and authenticating, 
	' the client sends the server a message, receives a message from the server,
	' and then terminates. Messages sent to and from the server are terminated
	' with '<EOF>'.
	Public Class SslTcpClient
		' complete is used to terminate the application when all 
		' asynchronous calls have completed or any call has thrown an exception.
		' complete might be used by any of the callback methods.
		Shared complete As Boolean = False
		' e stores any exception thrown by an asynchronous method so that
		' the mail application thread can display the exception and terminate gracefully.
		' e might be used by any of the callback methods.
		Shared e As Exception = Nothing
		' <snippet8>
		' readData and buffer holds the data read from the server.
		' They is used by the ReadCallback method.
		Shared readData As New StringBuilder()
		Shared buffer As Byte() = New Byte(2048) {}
		' </snippet8>
		'<snippet1>

		' The following method is invoked by the CertificateValidationDelegate.
		Public Shared Function ValidateServerCertificate(
            sender As Object, 
            certificate As X509Certificate, 
            chain As X509Chain, 
            sslPolicyErrors As SslPolicyErrors) As Boolean

			Console.WriteLine("Validating the server certificate.")

			If sslPolicyErrors = SslPolicyErrors.None Then Return True
		

			Console.WriteLine("Certificate error: {0}", sslPolicyErrors)

			' Do not allow this client to communicate with unauthenticated servers.
			Return False
		End Function
		'</snippet1>
		'<snippet2>
		Public Shared Function SelectLocalCertificate(
            sender As Object, 
            targetHost As String, 
            localCertificates As X509CertificateCollection, 
            remoteCertificate As X509Certificate, 
            acceptableIssuers As String()) As X509Certificate

			Console.WriteLine("Client is selecting a local certificate.")

			If acceptableIssuers IsNot Nothing AndAlso acceptableIssuers.Length > 0 AndAlso 
               localCertificates IsNot Nothing AndAlso localCertificates.Count > 0 Then
				' Use the first certificate that is from an acceptable issuer.
				For Each certificate As X509Certificate In localCertificates
					Dim issuer As String = certificate.Issuer
					If Array.IndexOf(acceptableIssuers, issuer) <> -1 Then
						Return certificate
					End If
				Next
			End If

			If localCertificates IsNot Nothing AndAlso localCertificates.Count > 0 Then
				Return localCertificates(0)
			End If

			Return Nothing
		End Function
		'</snippet2>
		'<snippet3>
		Shared Sub AuthenticateCallback(ar As IAsyncResult)

			Dim stream = CType(ar.AsyncState, SslStream)

			Try
				stream.EndAuthenticateAsClient(ar)
				Console.WriteLine("Authentication succeeded.")
				Console.WriteLine("Cipher: {0} strength {1}", stream.CipherAlgorithm, stream.CipherStrength)
				Console.WriteLine("Hash: {0} strength {1}", stream.HashAlgorithm, stream.HashStrength)
				Console.WriteLine("Key exchange: {0} strength {1}", stream.KeyExchangeAlgorithm, stream.KeyExchangeStrength)
				Console.WriteLine("Protocol: {0}", stream.SslProtocol)
				' Encode a test message into a byte array.
				' Signal the end of the message using the "<EOF>".
				Dim message As Byte() = Encoding.UTF8.GetBytes("Hello from the client.<EOF>")
				' Asynchronously send a message to the server.
				stream.BeginWrite(message, 0, message.Length, New AsyncCallback(AddressOf WriteCallback), stream)
			Catch authenticationException As Exception
				e = authenticationException
				complete = True
				Return
			End Try

		End Sub
		'</snippet3>
		'<snippet4>
		Shared Sub WriteCallback(ar As IAsyncResult)
			Dim stream = CType(ar.AsyncState, SslStream)
			Try
				Console.WriteLine("Writing data to the server.")
				stream.EndWrite(ar)
				' Asynchronously read a message from the server.
				stream.BeginRead(buffer, 0, buffer.Length, New AsyncCallback(AddressOf ReadCallback), stream)
			Catch writeException As Exception
				e = writeException
				complete = True
				Return
			End Try
		End Sub
		'</snippet4>
		'<snippet5>

		Shared Sub ReadCallback(ar As IAsyncResult)
			' Read the  message sent by the server.
			' The end of the message is signaled using the
			' "<EOF>" marker.
			Dim stream = CType(ar.AsyncState, SslStream)
			Dim byteCount As Integer
			Try
				Console.WriteLine("Reading data from the server.")
				byteCount = stream.EndRead(ar)
				' Use Decoder class to convert from bytes to UTF8
				' in case a character spans two buffers.
				Dim decoder As Decoder = Encoding.UTF8.GetDecoder()
				Dim chars = New Char(decoder.GetCharCount(buffer, 0, byteCount)) {}
				decoder.GetChars(buffer, 0, byteCount, chars, 0)
				readData.Append(chars)
				' Check for EOF or an empty message.
				If readData.ToString().IndexOf("<EOF>") = -1 AndAlso byteCount <> 0 Then
					' We are not finished reading.
					' Asynchronously read more message data from  the server.
					stream.BeginRead(buffer, 0, buffer.Length, New AsyncCallback(AddressOf ReadCallback), stream)
				Else
					Console.WriteLine("Message from the server: {0}", readData.ToString())
				End If
			Catch readException As Exception
				e = readException
				complete = True
				Return
			End Try
			complete = True
		End Sub
		'</snippet5>
		'<snippet7>
		Public Shared Function Main(args As String()) As Integer

			Dim serverName As String 
			If args Is Nothing OrElse args.Length < 2 Then
				Console.WriteLine("To start the client specify the host name and" + 
                                  " one or more client certificate file names.")
				Return 1
			End If
			'<snippet6>
			' Server name must match the host name and the name on the host's certificate. 
			serverName = args(0)
			' Create a TCP/IP client socket.
			Dim client As New TcpClient(serverName, 80)
			Console.WriteLine("Client connected.")
			' Create an SSL stream that will close the client's stream.
			Dim sslStream As New SslStream(
			    client.GetStream(), False, 
                New RemoteCertificateValidationCallback(AddressOf ValidateServerCertificate), 
                New LocalCertificateSelectionCallback(AddressOf SelectLocalCertificate))
			'</snippet6>
			' Create the certificate collection to hold the client's certificate.
			Dim clientCertificates As New X509CertificateCollection()
			Dim i = 1
			While i < args.Length
				Dim certificate As X509Certificate = X509Certificate.CreateFromCertFile(args(i))
				clientCertificates.Add(certificate)
				i += 1
			End While
			
            ' Begin authentication.
			' The server name must match the name on the server certificate.
			sslStream.BeginAuthenticateAsClient(
			    serverName, clientCertificates,
                SslProtocols.Ssl3, True, 
                New AsyncCallback(AddressOf AuthenticateCallback), sslStream)

			' User can press a key to exit application, or let the 
			' asynchronous calls continue until they complete.
			Console.WriteLine("To quit, press the enter key.")

			Do
				' Real world applications would do work here
				' while waiting for the asynchronous calls to complete.
			     Thread.Sleep(100)
			Loop While complete <> True AndAlso Console.KeyAvailable = False

			If Console.KeyAvailable Then
				Console.ReadLine()
				Console.WriteLine("Quitting.")
				client.Close()
				sslStream.Close()
				Return 1
			End If

			If e IsNot Nothing Then
				Console.WriteLine("An exception was thrown: {0}", e.ToString())
			End If

			sslStream.Close()
			client.Close()
			Console.WriteLine("Good bye.")
			Return 0

		End Function
		'</snippet7>

	End Class

End Namespace
