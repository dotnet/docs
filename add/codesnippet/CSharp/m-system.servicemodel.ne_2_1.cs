            Uri baseAddress = new Uri("http://localhost:8000/uesamples/service");

            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);
            NetNamedPipeBinding binding = new NetNamedPipeBinding("CalcConfig");