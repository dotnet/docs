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