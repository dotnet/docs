      string myDiscoFile = "http://localhost/MathService_cs.vsdisco";
      string myUrlKey = "http://localhost/MathService_cs.asmx?wsdl";
      DiscoveryClientProtocol myDiscoveryClientProtocol = 
            new DiscoveryClientProtocol();

      // Get the discovery document.
      DiscoveryDocument myDiscoveryDocument = 
         myDiscoveryClientProtocol.Discover(myDiscoFile);
      IEnumerator myEnumerator = 
            myDiscoveryDocument.References.GetEnumerator();
      while ( myEnumerator.MoveNext() )
      {
         ContractReference myContractReference =
            (ContractReference)myEnumerator.Current;

         // Get the DiscoveryClientProtocol from the ContractReference.
         myDiscoveryClientProtocol = myContractReference.ClientProtocol;
         myDiscoveryClientProtocol.ResolveAll();

         DiscoveryExceptionDictionary myExceptionDictionary 
            = myDiscoveryClientProtocol.Errors;

         if (myExceptionDictionary.Contains(myUrlKey))
         {
            Console.WriteLine("System generated exceptions.");

            // Get the exception from the DiscoveryExceptionDictionary.
            Exception myException = myExceptionDictionary[myUrlKey];

            Console.WriteLine(" Source : " + myException.Source);
            Console.WriteLine(" Exception : " + myException.Message);
         }
      }