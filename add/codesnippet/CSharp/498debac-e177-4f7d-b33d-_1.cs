            // Create ServiceDescription from a collection of service endpoints
            List<ServiceEndpoint> endpoints = new List<ServiceEndpoint>();
            ContractDescription conDescr = new ContractDescription("ICalculator");
            EndpointAddress endpointAddress = new EndpointAddress("http://localhost:8001/Basic");
            ServiceEndpoint ep = new ServiceEndpoint(conDescr, new BasicHttpBinding(), endpointAddress);
            endpoints.Add(ep);
            ServiceDescription sd2 = new ServiceDescription(endpoints);