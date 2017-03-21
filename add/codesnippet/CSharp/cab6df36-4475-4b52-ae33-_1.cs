         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");

         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " + noOfPortTypes);

         PortType myNewPortType = myPortTypeCollection["MathServiceSoap"];

         // Get the index in the collection.
         int index = myPortTypeCollection.IndexOf(myNewPortType);
         Console.WriteLine("Removing the PortType named " 
            + myNewPortType.Name);

         // Remove the PortType from the collection.
         myPortTypeCollection.Remove(myNewPortType);
         noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " 
            + noOfPortTypes);
         
         // Check whether the PortType exists in the collection.
         bool bContains = myPortTypeCollection.Contains(myNewPortType);
         Console.WriteLine("Port Type'" + myNewPortType.Name + "' exists: " 
            + bContains );

         Console.WriteLine("Adding the PortType");
         // Insert a new portType at the index location.
         myPortTypeCollection.Insert(index, myNewPortType);

         // Display the number of portTypes after adding a port.
         Console.WriteLine("Total number of PortTypes after "
            + "adding a new port: " + myServiceDescription.PortTypes.Count);

         bContains = myPortTypeCollection.Contains(myNewPortType);
         Console.WriteLine("Port Type'" + myNewPortType.Name + "' exists: " 
            + bContains );
         myServiceDescription.Write("MathService_New.wsdl");