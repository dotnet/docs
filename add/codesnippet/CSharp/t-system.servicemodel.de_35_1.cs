            Uri baseAddress = new Uri("http://localhost:8001/Simple");
            ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            serviceHost.AddServiceEndpoint(
                typeof(ICalculator),
                new WSHttpBinding(),
                "CalculatorServiceObject");

            // Enable Mex
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(smb);
 
            serviceHost.Open();

            ContractDescription cd0 = new ContractDescription("ICalculator");
            ContractDescription cd1 = new ContractDescription("ICalculator", "http://www.tempuri.org");
            ContractDescription cd2 = ContractDescription.GetContract(typeof(ICalculator));
            CalculatorService calcSvc = new CalculatorService();
            ContractDescription cd3 = ContractDescription.GetContract(typeof(ICalculator), calcSvc);
            ContractDescription cd4 = ContractDescription.GetContract(typeof(ICalculator), typeof(CalculatorService));
            ContractDescription cd = serviceHost.Description.Endpoints[0].Contract;         

            Console.WriteLine("Displaying information for contract: {0}", cd.Name.ToString());

            KeyedByTypeCollection<IContractBehavior> behaviors = cd.Behaviors;
            Console.WriteLine("\tDisplay all behaviors:");
            foreach (IContractBehavior behavior in behaviors)
            {
                Console.WriteLine("\t\t" + behavior.ToString());
            }

            Type type = cd.CallbackContractType;

            string configName = cd.ConfigurationName;
            Console.WriteLine("\tConfiguration name: {0}", configName);

            Type contractType = cd.ContractType;
            Console.WriteLine("\tContract type: {0}", contractType.ToString());

            bool hasProtectionLevel = cd.HasProtectionLevel;
            if (hasProtectionLevel)
            {
                ProtectionLevel protectionLevel = cd.ProtectionLevel;
                Console.WriteLine("\tProtection Level: {0}", protectionLevel.ToString());
            }

            
            string name = cd.Name;
            Console.WriteLine("\tName: {0}", name);

            string namespc = cd.Namespace;
            Console.WriteLine("\tNamespace: {0}", namespc);

            OperationDescriptionCollection odc = cd.Operations;
            Console.WriteLine("\tDisplay Operations:");
            foreach (OperationDescription od in odc)
            {
                Console.WriteLine("\t\t" + od.Name);
            }

            SessionMode sm = cd.SessionMode;
            Console.WriteLine("\tSessionMode: {0}", sm.ToString());

            Collection<ContractDescription> inheretedContracts = cd.GetInheritedContracts();
            Console.WriteLine("\tInherited Contracts:");
            foreach (ContractDescription contractdescription in inheretedContracts)
            {
                Console.WriteLine("\t\t" + contractdescription.Name);
            }

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            // Close the ServiceHostBase to shutdown the service.
            serviceHost.Close();