    public static WebProxy CreateProxyAndCheckBypass(bool bypassLocal)
    {
        // Do not use the proxy server for Contoso.com URIs.
        string[] bypassList = new string[]{";*.Contoso.com"};
        WebProxy proxy =  new WebProxy("http://contoso", 
            bypassLocal, 
            bypassList);
            
        // Test the bypass list.
        if (!proxy.IsBypassed(new Uri("http://www.Contoso.com")))
        {
            Console.WriteLine("Bypass not working!");
            return null;
        } 
        else 
        {
            Console.WriteLine("Bypass is working.");
            return proxy;
        }
    }