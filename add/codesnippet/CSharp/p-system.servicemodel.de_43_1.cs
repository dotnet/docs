            ServiceEndpoint endpnt = serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            Console.WriteLine("Address: {0}", endpnt.Address);