        // Set up a listener.
        HttpListener listener = new HttpListener();
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        prefixes.Add(@"http://localhost:8080/");
        prefixes.Add(@"http://contoso.com:8080/");

        // Specify the authentication delegate.
        listener.AuthenticationSchemeSelectorDelegate = 
            new AuthenticationSchemeSelector (AuthenticationSchemeForClient);

        // Start listening for requests and process them 
        // synchronously.
        listener.Start();