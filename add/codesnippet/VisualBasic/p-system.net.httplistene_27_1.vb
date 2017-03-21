
            ' When the client is not authenticated, there is no Identity.
            If context.User Is Nothing Then
                message.Append("<HTML><BODY><p> Hello local user! </p></BODY></HTML>")
            Else
                ' Get the requester's identity.
                Dim identity As System.Security.Principal.WindowsIdentity = WindowsIdentity.GetCurrent()
                ' Construct the response body.
                message.AppendFormat("<HTML><BODY><p> Hello {0}!<br/>", identity.Name)
                message.AppendFormat("You were authenticated using {0}.</p>", identity.AuthenticationType)
                message.Append("</BODY></HTML>")
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