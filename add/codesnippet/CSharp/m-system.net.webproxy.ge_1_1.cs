        // The following method creates a WebProxy object that uses Internet Explorer's  
        // detected script if it is found in the registry; otherwise, it 
        // tries to use Web proxy auto-discovery to set the proxy used for
        // the request.
    
        public static void CheckAutoGlobalProxyForRequest(Uri resource)
        {
            WebProxy proxy = new WebProxy();
        
            // Display the proxy's properties.
            DisplayProxyProperties(proxy);
        
            // See what proxy is used for the resource.
            Uri resourceProxy = proxy.GetProxy(resource);

            // Test to see whether a proxy was selected.
            if (resourceProxy == resource)
            {
                Console.WriteLine("No proxy for {0}", resource);
            } 
            else
            {
                Console.WriteLine("Proxy for {0} is {1}", resource.OriginalString,
                    resourceProxy.ToString());
            }
        }