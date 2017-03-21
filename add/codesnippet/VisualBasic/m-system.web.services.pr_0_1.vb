        ' Math is a proxy class derived from HttpGetClientProtocol.
        Dim myHttpGetClientProtocol As New Math()

        ' Obtain password from a secure store.
        Dim SecurelyStoredPassword As String = String.Empty

        ' Set the client-side credentials using the Credentials property.
        Dim credentials = _
            New NetworkCredential("Joe", "mydomain", SecurelyStoredPassword)
        myHttpGetClientProtocol.Credentials = credentials

        ' Allow the server to redirect the request.
        myHttpGetClientProtocol.AllowAutoRedirect = True
        Console.WriteLine("Auto redirect is: " _
            & myHttpGetClientProtocol.AllowAutoRedirect)