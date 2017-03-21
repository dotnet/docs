            // Iterate through the endpoints contained in the ServiceDescription
            ServiceEndpointCollection sec = svcDesc.Endpoints;
            foreach (ServiceEndpoint se in sec)
            {
                Console.WriteLine("Endpoint:");
                Console.WriteLine("\tAddress: {0}", se.Address.ToString());
                Console.WriteLine("\tBinding: {0}", se.Binding.ToString());
                Console.WriteLine("\tContract: {0}", se.Contract.ToString());
                KeyedByTypeCollection<IEndpointBehavior> behaviors = se.Behaviors;
                foreach (IEndpointBehavior behavior in behaviors)
                {
                    Console.WriteLine("Behavior: {0}", behavior.ToString());
                }
            }