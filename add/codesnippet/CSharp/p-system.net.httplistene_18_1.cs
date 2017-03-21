    public static void ShowRequestProperties1 (HttpListenerRequest request)
    {
        // Display the MIME types that can be used in the response.
        string[] types = request.AcceptTypes;
        if (types != null)
        {
            Console.WriteLine("Acceptable MIME types:");
            foreach (string s in types)
            {
                Console.WriteLine(s);
            }
        }
        // Display the language preferences for the response.
        types = request.UserLanguages;
        if (types != null)
        {
            Console.WriteLine("Acceptable natural languages:");
            foreach (string l in types)
            {
                Console.WriteLine(l);
            }
        }
        
        // Display the URL used by the client.
        Console.WriteLine("URL: {0}", request.Url.OriginalString);
        Console.WriteLine("Raw URL: {0}", request.RawUrl);
        Console.WriteLine("Query: {0}", request.QueryString);

        // Display the referring URI.
        Console.WriteLine("Referred by: {0}", request.UrlReferrer);

        //Display the HTTP method.
        Console.WriteLine("HTTP Method: {0}", request.HttpMethod);
        //Display the host information specified by the client;
        Console.WriteLine("Host name: {0}", request.UserHostName);
        Console.WriteLine("Host address: {0}", request.UserHostAddress);
        Console.WriteLine("User agent: {0}", request.UserAgent);
    }