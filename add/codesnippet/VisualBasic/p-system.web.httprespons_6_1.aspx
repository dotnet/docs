        ' Check whether the request is sent
        ' over HTTPS. If not, do not return
        ' content to the client.
        If (Request.IsSecureConnection = False) Then      
            Response.SuppressContent = True
        End If