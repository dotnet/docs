            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");
            CalculatorService service = new CalculatorService();
            ServiceHost serviceHost = new ServiceHost(service, baseAddress);
            InstanceContext instanceContext = new InstanceContext(serviceHost, service);

            IExtensionCollection<InstanceContext> extensions = instanceContext.Extensions;