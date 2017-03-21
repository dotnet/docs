        private void PrintDescription(ServiceHost sh)
        {
            // Declare variables.
            int i, j, k, l, c;
            ServiceDescription servDesc = sh.Description;
            OperationDescription opDesc;
            ContractDescription contractDesc;
            MessageDescription methDesc;
            MessageBodyDescription mBodyDesc;
            MessagePartDescription partDesc;
            IServiceBehavior servBeh;
            ServiceEndpoint servEP;

            // Print the behaviors of the service.
            Console.WriteLine("Behaviors:");
            for (c = 0; c < servDesc.Behaviors.Count; c++)
            {
                servBeh = servDesc.Behaviors[c];
                Console.WriteLine("\t{0}", servBeh.ToString());                
            }

            // Print the endpoint descriptions of the service.
            Console.WriteLine("Endpoints");
            for (i = 0; i < servDesc.Endpoints.Count; i++)
            {
                // Print the endpoint names.
                servEP = servDesc.Endpoints[i];
                Console.WriteLine("\tName: {0}", servEP.Name);
                contractDesc = servEP.Contract;

                Console.WriteLine("\tOperations:");
                for (j = 0; j < contractDesc.Operations.Count; j++)
                {
                    // Print the operation names.
                    opDesc = servEP.Contract.Operations[j];
                    Console.WriteLine("\t\t{0}", opDesc.Name);
                    Console.WriteLine("\t\tActions:");
                    for (k  = 0; k < opDesc.Messages.Count; k++)
                    {
                        // Print the message action. 
                        methDesc = opDesc.Messages[k];
                        Console.WriteLine("\t\t\tAction:{0}", methDesc.Action);
                       
                        // Check for the existence of a body, then the body description.
                        mBodyDesc = methDesc.Body;
                        if (mBodyDesc.Parts.Count > 0)
                        {
                            for (l = 0; l < methDesc.Body.Parts.Count; l++)
                            {
                                partDesc = methDesc.Body.Parts[l];
                                Console.WriteLine("\t\t\t\t{0}",partDesc.Name);
                            }
                        }
                    }
                }
            }
        }