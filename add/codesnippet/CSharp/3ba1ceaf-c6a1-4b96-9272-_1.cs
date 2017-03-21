         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");

         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " + noOfPortTypes);

         PortType myNewPortType = myPortTypeCollection["MathServiceSoap"];

         // Get the index in the collection.
         int index = myPortTypeCollection.IndexOf(myNewPortType);