            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");
            CalculatorService service = new CalculatorService();
            ServiceHost serviceHost = new ServiceHost(service, baseAddress);
            InstanceContext instanceContext = new InstanceContext(serviceHost,service);

            string info = "";
            info += "    " + "State: " + instanceContext.State.ToString() + "\n";
            info += "    " + "ManualFlowControlLimit: " + instanceContext.ManualFlowControlLimit.ToString() + "\n";
            info += "    " + "HashCode: " + instanceContext.GetHashCode().ToString() + "\n";
            Console.WriteLine(info);