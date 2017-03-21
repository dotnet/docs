    public static void SimpleListenerWithUnsafeAuthentication(string[] prefixes)
    {
        // URI prefixes are required,
        // for example "http://contoso.com:8080/index/".
        if (prefixes == null || prefixes.Length == 0)
          throw new ArgumentException("prefixes");
        // Set up a listener.
        HttpListener listener = new HttpListener();
        foreach (string s in prefixes)
        {
            listener.Prefixes.Add(s);
        }
        listener.Start();
        // Specify Negotiate as the authentication scheme.
        listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
        // If NTLM is used, we will allow multiple requests on the same
        // connection to use the authentication information of first request.
        // This improves performance but does reduce the security of your 
        // application. 
        listener.UnsafeConnectionNtlmAuthentication = true;
        // This listener does not want to receive exceptions 
        // that occur when sending the response to the client.
        listener.IgnoreWriteExceptions = true;
        Console.WriteLine("Listening...");
        // ... process requests here.

        listener.Close();
    }