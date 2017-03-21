            BasicHttpBinding binding = new BasicHttpBinding();
            Uri listenUri = new Uri("http://localhost:8000/MyListenUri");
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service3");
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address, listenUri);