            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            serviceHost.Open();

            ChannelDispatcher dispatcher = (ChannelDispatcher)serviceHost.ChannelDispatchers[0];
            bool isTransactedAccept = dispatcher.IsTransactedAccept;