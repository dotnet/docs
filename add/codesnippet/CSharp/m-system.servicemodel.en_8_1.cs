            // Create the service host.
            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator));

            // Create the binding.
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType =
                 MessageCredentialType.Windows;

            // Disable credential negotiation and establishment of the
            // security context.
            binding.Security.Message.NegotiateServiceCredential = false;
            binding.Security.Message.EstablishSecurityContext = false;

            // Create a URI for the endpoint address.
            Uri httpUri = new Uri("http://localhost/Calculator");

            // Create the EndpointAddress with the SPN for the Identity.
            EndpointAddress ea = new EndpointAddress(httpUri,
                EndpointIdentity.CreateSpnIdentity("service_spn_name"));

            // Get the contract from the ICalculator interface (not shown here).
            // See the sample applications for an example of the ICalculator.
            ContractDescription contract = ContractDescription.GetContract(
                typeof(ICalculator));

            // Create a new ServiceEndpoint.
            ServiceEndpoint se = new ServiceEndpoint(contract, binding, ea);

            // Add the service endpoint to the service.
            myServiceHost.Description.Endpoints.Add(se);

            // Open the service.
            myServiceHost.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();

            // Close the service. 
            myServiceHost.Close();