            Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Open();
                OperationContext operationContext = OperationContext.Current;
                InstanceContext instanceContext = operationContext.InstanceContext;
                instanceContext.IncrementManualFlowControlLimit(100);
            }