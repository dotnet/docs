    public static void PermanentRedirect(HttpListenerRequest request, HttpListenerResponse response)
    {
        if (request.Url.OriginalString == @"http://www.contoso.com/index.html")
        {
            // Sets the location header, status code and status description.
            response.Redirect(@"http://www.contoso.com/indexServer/index.html");
        }
    }