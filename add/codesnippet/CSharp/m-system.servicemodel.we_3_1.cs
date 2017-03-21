            Uri[] baseAddresses = { new Uri("http://localhost/one"), new Uri("http://localhost/two") };
            object mySingleton = GetObject();
            WebServiceHost host = new WebServiceHost(mySingleton, baseAddresses);