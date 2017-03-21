            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                serviceHost.Open();
                ServiceEndpointCollection endpoints = serviceHost.Description.Endpoints;
                ServiceEndpoint endpoint = endpoints.Find(typeof(ICalculator));

                NetTcpBinding binding = (NetTcpBinding) endpoint.Binding;

                NetTcpSecurity security = binding.Security;
                MessageSecurityOverTcp msTcp = security.Message;

                Console.WriteLine("Dumping NetTcpSecurity object:");
                Console.WriteLine("\tMessageSecurityOverTcp:");
                Console.WriteLine("\t\tAlgorithm Suite: {0}", msTcp.AlgorithmSuite);
                Console.WriteLine("\t\tClient Credential Type: {0}", msTcp.ClientCredentialType);

                Console.WriteLine("\tSecurity Mode: {0}", security.Mode);

                TcpTransportSecurity tsTcp = security.Transport;
                Console.WriteLine("\tTcpTransportSecurity:");
                Console.WriteLine("\t\tClient Credential Type: {0}", tsTcp.ClientCredentialType);
                Console.WriteLine("\t\tProtectionLevel: {0}", tsTcp.ProtectionLevel);

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }