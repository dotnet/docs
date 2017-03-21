        // Create a new request to the mentioned URL.
        HttpWebRequest ^ myWebRequest =
            (HttpWebRequest ^) (WebRequest::Create("http://www.microsoft.com"));

        // Obtain the 'Proxy' of the  Default browser.  
        IWebProxy ^ proxy = myWebRequest->Proxy;
        // Print the Proxy Url to the console.
        if (proxy) 
        {
            Console::WriteLine("Proxy: {0}",
                proxy->GetProxy(myWebRequest->RequestUri));
        } 
        else 
        {
            Console::WriteLine("Proxy is null; no proxy will be used");
        }

        WebProxy ^ myProxy = gcnew WebProxy;

        Console::WriteLine("\nPlease enter the new Proxy Address that is to be set:");
        Console::WriteLine("(Example:http://myproxy.example.com:port)");
        String ^ proxyAddress;

        try 
        {
            proxyAddress = Console::ReadLine();
            if (proxyAddress->Length > 0) {
                Console::WriteLine("\nPlease enter the Credentials ");
                Console::WriteLine("Username:");
                String ^ username;
                username = Console::ReadLine();
                Console::WriteLine("\nPassword:");
                String ^ password;
                password = Console::ReadLine();
                // Create a new Uri object.
                Uri ^ newUri = gcnew Uri(proxyAddress);
                // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
                myProxy->Address = newUri;
                // Create a NetworkCredential object and associate it with the Proxy property of request object.
                myProxy->Credentials =
                    gcnew NetworkCredential(username, password);
                myWebRequest->Proxy = myProxy;
            }
            Console::WriteLine("\nThe Address of the  new Proxy settings are {0}",
                          myProxy->Address);
            HttpWebResponse ^ myWebResponse =
                (HttpWebResponse ^) (myWebRequest->GetResponse());