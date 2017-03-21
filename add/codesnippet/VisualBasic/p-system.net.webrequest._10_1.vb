            ' Create a request for the URL. 		
            Dim request As WebRequest = WebRequest.Create("http://www.contoso.com/default.html")
            ' If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials
            ' Get the response.
            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)