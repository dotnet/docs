            BasicHttpBinding binding = new BasicHttpBinding();
            Uri listenUri = new Uri("http://localhost:8000/MyListenUri");
            String address = "http://localhost:8000/servicemodelsamples/service2";
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address, listenUri);