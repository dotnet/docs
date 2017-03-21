        MyMath.Math math = new MyMath.Math();

        // Set the proxy server to proxyserver, set the port to 80, and specify to bypass the proxy server
        // for local addresses.
        IWebProxy proxyObject = new WebProxy("http://proxyserver:80", true);
        math.Proxy = proxyObject;

        // Call the Add XML Web service method.
        int total = math.Add(8, 5);