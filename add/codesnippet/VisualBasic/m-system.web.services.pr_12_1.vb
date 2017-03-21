        ' Math is a proxy class derived from HttpPostClientProtocol.
        Dim myHttpPostClientProtocol As New Math()

        ' Obtain password from a secure store.
        Dim SecurelyStoredPassword As String = String.Empty

        ' Set the client-side credentials using the Credentials property.
        myHttpPostClientProtocol.Credentials = System.Net.CredentialCache.DefaultCredentials

        ' Allow the server to redirect the request.
        myHttpPostClientProtocol.AllowAutoRedirect = True
        Console.WriteLine("Auto redirect is: " & _
            myHttpPostClientProtocol.AllowAutoRedirect)