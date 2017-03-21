            BasicHttpBinding binding = new BasicHttpBinding();
            Uri address = new Uri("http://localhost:8000/servicemodelsamples/service/basic");
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, address);