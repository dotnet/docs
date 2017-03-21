            // Create an EndpointAddress with a specified address.
            EndpointAddress epa1 = new EndpointAddress("http://localhost/ServiceModelSamples");
            Console.WriteLine("The URI of the EndpointAddress is {0}:", epa1.Uri);
            Console.WriteLine();

            //Initialize an EndpointAddress10 from the endpointAddress.
            EndpointAddress10 epa10 = EndpointAddress10.FromEndpointAddress(epa1);

            //Serialize and then deserializde the Endpoint10 type.

            //Convert the EndpointAddress10 back into an EndpointAddress.
            EndpointAddress epa2 = epa10.ToEndpointAddress();

            Console.WriteLine("The URI of the EndpointAddress is still {0}:", epa2.Uri);
            Console.WriteLine();