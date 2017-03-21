        private void Run()
        {
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            Uri baseAddress = new Uri("http://localhost:1066/calculator");
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddress);
            sh.AddServiceEndpoint(typeof(ICalculator), b, "");

            // Find the ContractDescription of the operation to find.
            ContractDescription cd = sh.Description.Endpoints[0].Contract;
            OperationDescription myOperationDescription = cd.Operations.Find("Add");

            // Find the serializer behavior.
            XmlSerializerOperationBehavior  serializerBehavior =
                myOperationDescription.Behaviors.
                   Find<XmlSerializerOperationBehavior>();

            // If the serializer is not found, create one and add it.
            if (serializerBehavior == null)
            {
                serializerBehavior = new XmlSerializerOperationBehavior(myOperationDescription);
                myOperationDescription.Behaviors.Add(serializerBehavior);
            }
            
            // Change style of the serialize attribute.
            serializerBehavior.XmlSerializerFormatAttribute.Style = OperationFormatStyle.Document;
                        
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            sh.Close();
        }