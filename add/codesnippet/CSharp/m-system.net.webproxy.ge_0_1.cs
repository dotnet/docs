    public static void CheckDefaultProxyForRequest(Uri resource)
    {
        WebProxy proxy = (WebProxy) WebProxy.GetDefaultProxy();
                
        // See what proxy is used for resource.
        Uri resourceProxy = proxy.GetProxy(resource);

        // Test to see whether a proxy was selected.
        if (resourceProxy == resource)
        {
            Console.WriteLine("No proxy for {0}", resource);
        } 
        else
        {
            Console.WriteLine("Proxy for {0} is {1}", resource.ToString(),
                resourceProxy.ToString());
        }
    }