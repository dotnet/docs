        private void DataContractBehavior()
        {
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            Uri baseAddress = new Uri("http://localhost:1066/calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddress);
            sh.AddServiceEndpoint(typeof(ICalculator), b, "");

            // Find the ContractDescription of the operation to find.
            ContractDescription cd = sh.Description.Endpoints[0].Contract;
            OperationDescription myOperationDescription = cd.Operations.Find("Add");

            // Find the serializer behavior.
            DataContractSerializerOperationBehavior serializerBehavior =
                myOperationDescription.Behaviors.
                   Find<DataContractSerializerOperationBehavior>();

            // If the serializer is not found, create one and add it.
            if (serializerBehavior == null)
            {
                serializerBehavior = new DataContractSerializerOperationBehavior(myOperationDescription);
                myOperationDescription.Behaviors.Add(serializerBehavior);
            }

            // Change the settings of the behavior.
            serializerBehavior.MaxItemsInObjectGraph = 10000;
            serializerBehavior.IgnoreExtensionDataObject = true;
            
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
        }