'NCLListener
' <snippet8>
Imports System
Imports System.Net
Imports System.Text
Imports System.Security.Principal

Public Class NetListener
    ' <snippet5>
    Private Shared message403 As String
    Private Shared preMade403Response As HttpListenerResponse
    Private Shared Sub SendBadCertificateResponse(ByVal response As HttpListenerResponse)
        
        If preMade403Response Is Nothing Then
            ' Set up an authentication error response template.
            response.StatusCode = Cint(HttpStatusCode.Forbidden)
            response.StatusDescription = "403 Forbidden"
            response.ProtocolVersion = New Version("1.1")
            response.SendChunked = False
        Else
            response.CopyFrom(preMade403Response) 
        End If
        
        ' The response body cannot be saved in the template.
        Dim message As New StringBuilder()
        message.Append("<HTML><BODY>")
        message.Append("<p> Error message 403: Access is denied due to a missing or invalid client certificate.</p>")
        message.Append("</BODY></HTML>")
        message403 = message.ToString()

        ' Turn the error message into a byte array using the 
        ' encoding from the response when present.
        Dim encoding As System.Text.Encoding = response.ContentEncoding
        If encoding Is Nothing Then
            encoding = System.Text.Encoding.UTF8
            response.ContentEncoding = encoding
        End If

        Dim buffer() As Byte = encoding.GetBytes(message403)
        response.ContentLength64 = buffer.Length
        ' Write the error message.
        Dim stream As System.IO.Stream = response.OutputStream
        stream.Write(buffer, 0, buffer.Length)
        ' Send the response.
        response.Close()
    End Sub
    ' </snippet5>

    ' <snippet1>
    Private Shared Function AuthenticationSchemeForClient(ByVal request As HttpListenerRequest) As AuthenticationSchemes
        Console.WriteLine("Client authentication protocol selection in progress...")
        ' Do not authenticate local machine requests.
        If request.RemoteEndPoint.Address.Equals(IPAddress.Loopback) Then
            Return AuthenticationSchemes.None
        Else
            Return AuthenticationSchemes.IntegratedWindowsAuthentication
        End If
    End Function
    ' </snippet1>
    Public Shared Sub Main()
        ' <snippet2>
        ' Set up a listener.
        Dim listener As New HttpListener()
        Dim prefixes As HttpListenerPrefixCollection = listener.Prefixes
        prefixes.Add("http://localhost:8080/")
        prefixes.Add("http://contoso.com:8080/")

        ' Specify the authentication delegate.
        listener.AuthenticationSchemeSelectorDelegate = New AuthenticationSchemeSelector(AddressOf AuthenticationSchemeForClient)

        ' Start listening for requests and process them 
        ' synchronously.
        listener.Start()
        ' </snippet2>
        Do
            ' <snippet3>
            Console.WriteLine("Listening for {0} prefixes...", listener.Prefixes.Count)
            Dim context As HttpListenerContext = listener.GetContext()
            Dim request As HttpListenerRequest = context.Request
            Console.WriteLine("Received a request.")
            ' This server requires a valid client certificate
            ' for requests that are not sent from the local computer.

            ' Did the client omit the certificate or send an invalid certificate?
            If request.IsAuthenticated AndAlso request.GetClientCertificate() Is Nothing OrElse request.ClientCertificateError <> 0 Then
                ' Send a 403 response.
                Dim badCertificateResponse As HttpListenerResponse = context.Response
                SendBadCertificateResponse(badCertificateResponse)
                Console.WriteLine("Client has invalid certificate.")
                Continue Do
            End If
            ' </snippet3>
            Dim message As New StringBuilder()
            ' <snippet7>

            ' When the client is not authenticated, there is no Identity.
            If context.User Is Nothing Then
                message.Append("<HTML><BODY><p> Hello local user! </p></BODY></HTML>")
            Else
                ' <snippet6>
                ' Get the requester's identity.
                Dim identity As System.Security.Principal.WindowsIdentity = WindowsIdentity.GetCurrent()
                ' Construct the response body.
                message.AppendFormat("<HTML><BODY><p> Hello {0}!<br/>", identity.Name)
                message.AppendFormat("You were authenticated using {0}.</p>", identity.AuthenticationType)
                message.Append("</BODY></HTML>")
                ' </snippet6>
            End If

            ' Configure the response.
            Dim response As HttpListenerResponse = context.Response

            ' Use the encoding from the response if one has been set.
            ' Otherwise, use UTF8.
            Dim encoding As System.Text.Encoding = response.ContentEncoding
            If encoding Is Nothing Then
                encoding = System.Text.Encoding.UTF8
                response.ContentEncoding = encoding
            End If
            Dim buffer() As Byte = encoding.GetBytes(message.ToString())
            response.ContentLength64 = buffer.Length
            response.StatusCode = CInt(HttpStatusCode.OK)
            response.StatusDescription = "OK"
            response.ProtocolVersion = New Version("1.1")
            ' Don't keep the TCP connection alive
            ' We don't expect multiple requests from the same client.
            response.KeepAlive = False
            ' Write the response body.
            Dim stream As System.IO.Stream = response.OutputStream
            stream.Write(buffer, 0, buffer.Length)
            ' </snippet7>
            ' <snippet4>
            Console.WriteLine("Request complete. Press q to quit, enter to continue.")
            Dim answer As String = Console.ReadLine()
            If answer.StartsWith("q") Then
                Console.WriteLine("bye.")
                listener.Close()
                Exit Do
            End If
            ' </snippet4>
        Loop
    End Sub
End Class
' </snippet8>