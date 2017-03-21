            WSHttpBinding binding = new WSHttpBinding();
            serviceHost.AddServiceEndpoint(typeof(ICalculator), binding, "http://localhost:8000/servicemodelsamples/service/basic");