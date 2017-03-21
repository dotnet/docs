         PortTypeCollection myPortTypeCollection;

         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");

         myPortTypeCollection = myServiceDescription.PortTypes;
         int noOfPortTypes = myServiceDescription.PortTypes.Count;
         Console.WriteLine("\nTotal number of PortTypes: " 
            + myServiceDescription.PortTypes.Count);

         // Copy the collection into an array.
          PortType[] myPortTypeArray = new PortType[noOfPortTypes];
          myPortTypeCollection.CopyTo(myPortTypeArray, 0);

         // Display names of all PortTypes.
          for(int i = 0; i < noOfPortTypes; i++)
             Console.WriteLine("PortType name: " + myPortTypeArray[i].Name);
          myServiceDescription.Write("MathService_New.wsdl");