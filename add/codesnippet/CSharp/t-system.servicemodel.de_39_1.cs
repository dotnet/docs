            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            ContractDescription cd = new ContractDescription("Calculator");
            ServiceEndpoint svcEndpoint = new ServiceEndpoint(cd);
            
            ServiceEndpoint endpnt = serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            Console.WriteLine("Address: {0}", endpnt.Address);

            // Enable Mex
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);

            serviceHost.Open();