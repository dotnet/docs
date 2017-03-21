    public static void TemporaryRedirect(HttpListenerRequest request, HttpListenerResponse response)
    {
        if (request.Url.OriginalString == @"http://www.contoso.com/index.html")
        {
            response.RedirectLocation = @"http://www.contoso.com/indexServer/index.html";
        }
    }