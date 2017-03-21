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