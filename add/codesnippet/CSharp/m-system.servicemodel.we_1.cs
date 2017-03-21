            Uri[] baseAddresses = { new Uri("http://localhost/one"), new Uri("http://localhost/two") };
            WebServiceHost host = new WebServiceHost(typeof(CalcService), baseAddresses);