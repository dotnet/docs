        // Create a new request to the mentioned URL.				
        HttpWebRequest myWebRequest=(HttpWebRequest)WebRequest.Create("http://www.microsoft.com");

        // Obtain the 'Proxy' of the  Default browser.  
        IWebProxy proxy = myWebRequest.Proxy;
        // Print the Proxy Url to the console.
        if (proxy != null)
        {
            Console.WriteLine("Proxy: {0}", proxy.GetProxy(myWebRequest.RequestUri));
        } 
        else
        {
            Console.WriteLine("Proxy is null; no proxy will be used");
        }

        WebProxy myProxy=new WebProxy();

        Console.WriteLine("\nPlease enter the new Proxy Address that is to be set:");
        Console.WriteLine("(Example:http://myproxy.example.com:port)");
        string proxyAddress;

        try
        {
            proxyAddress =Console.ReadLine();
            if(proxyAddress.Length>0)
            {
                Console.WriteLine("\nPlease enter the Credentials (may not be needed)");
                Console.WriteLine("Username:");
                string username;
                username =Console.ReadLine();
                Console.WriteLine("\nPassword:");
                string password;
                password =Console.ReadLine();					
                // Create a new Uri object.
                Uri newUri=new Uri(proxyAddress);
                // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                myProxy.Address=newUri;
                // Create a NetworkCredential object and associate it with the 
                // Proxy property of request object.
                myProxy.Credentials=new NetworkCredential(username,password);
                myWebRequest.Proxy=myProxy;
            }
            Console.WriteLine("\nThe Address of the  new Proxy settings are {0}",myProxy.Address);
            HttpWebResponse myWebResponse=(HttpWebResponse)myWebRequest.GetResponse();