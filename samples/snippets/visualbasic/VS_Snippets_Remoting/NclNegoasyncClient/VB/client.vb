'<snippet0>
Imports System.Text
Imports System.Net.Sockets
Imports System.Net.Security
Imports System.Net

Namespace Examples.NegotiateStreamExample

	Public Class ASynchronousAuthenticatingTcpClient

		Shared client As TcpClient = Nothing

		Public Shared Sub Main(args As String())
			'<snippet2>
			'<snippet1>
			' Establish the remote endpoint for the socket.
			' For this example, use the local machine.
			Dim ipHostInfo = Dns.GetHostEntry("localhost")
			Dim ipAddress = ipHostInfo.AddressList(0)

			' Client and server use port 11000. 
			Dim remoteEP As New IPEndPoint(ipAddress, 11000)

			' Create a TCP/IP socket.
			client = New TcpClient()

			' Connect the socket to the remote endpoint.
			client.Connect(remoteEP)
			Console.WriteLine("Client connected to {0}.", remoteEP.ToString())

			' Ensure the client does not close when there is 
			' still data to be sent to the server.
			client.LingerState = (New LingerOption(True, 0))

			'<snippet3>
			' Request authentication.
			Dim clientStream = client.GetStream()
			Dim authStream As New NegotiateStream(clientStream, False)
			'</snippet1>     

			' Pass the NegotiateStream as the AsyncState object 
			' so that it is available to the callback delegate.
			Dim ar = authStream.BeginAuthenticateAsClient(
                New AsyncCallback(AddressOf EndAuthenticateCallback), authStream)
			'</snippet2>

			Console.WriteLine("Client waiting for authentication...")

			' Wait until the result is available.
			ar.AsyncWaitHandle.WaitOne()

			' Display the properties of the authenticated stream.
			AuthenticatedStreamReporter.DisplayProperties(authStream)

			' Send a message to the server.
			' Encode the test data into a byte array.
			Dim message = Encoding.UTF8.GetBytes("Hello from the client.")
			ar = authStream.BeginWrite(message, 0, message.Length, 
                New AsyncCallback(AddressOf EndWriteCallback), authStream)
			'</snippet3>
			ar.AsyncWaitHandle.WaitOne()
			Console.WriteLine("Sent {0} bytes.", message.Length)

			' Close the client connection.
			authStream.Close()
			Console.WriteLine("Client closed.")

		End Sub

		'<snippet5>
		' The following method is called when the authentication completes.
		Public Shared Sub EndAuthenticateCallback(ar As IAsyncResult)

			Console.WriteLine("Client ending authentication...")
			Dim authStream = CType(ar.AsyncState, NegotiateStream)
			Console.WriteLine("ImpersonationLevel: {0}", authStream.ImpersonationLevel)

			' End the asynchronous operation.
			authStream.EndAuthenticateAsClient(ar)

		End Sub

		'</snippet5>
		'<snippet4>
		' The following method is called when the write operation completes.
		Public Shared Sub EndWriteCallback(ar As IAsyncResult)

			Console.WriteLine("Client ending write operation...")
			Dim authStream = CType(ar.AsyncState, NegotiateStream)

			' End the asynchronous operation.
			authStream.EndWrite(ar)

		End Sub
		'</snippet4>
	End Class

	'<snippet6>
	' The following class displays the properties of an AuthenticatedStream.
	Public Class AuthenticatedStreamReporter
		Public Shared Sub DisplayProperties(stream As AuthenticatedStream)
			Console.WriteLine("IsAuthenticated: {0}", stream.IsAuthenticated)
			Console.WriteLine("IsMutuallyAuthenticated: {0}", stream.IsMutuallyAuthenticated)
			Console.WriteLine("IsEncrypted: {0}", stream.IsEncrypted)
			Console.WriteLine("IsSigned: {0}", stream.IsSigned)
			Console.WriteLine("IsServer: {0}", stream.IsServer)
		End Sub
	End Class
	'</snippet6>
End Namespace
' </snippet0>
