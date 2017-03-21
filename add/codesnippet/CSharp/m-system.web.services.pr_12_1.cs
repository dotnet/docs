        // Math is a proxy class derived from HttpPostClientProtocol.
        HttpPostClientProtocol myHttpPostClientProtocol = new Math();

        // Obtain password from a secure store.
        String SecurelyStoredPassword = String.Empty;

        // Set the client-side credentials using the Credentials property.
        myHttpPostClientProtocol.Credentials = System.Net.CredentialCache.DefaultCredentials;

        // Allow the server to redirect the request.
        myHttpPostClientProtocol.AllowAutoRedirect = true;
        Console.WriteLine("Auto redirect is: " + 
            myHttpPostClientProtocol.AllowAutoRedirect);