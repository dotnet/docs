      DiscoveryClientProtocol myProtocol = new DiscoveryClientProtocol();

      // Get the DiscoveryDocument.
      DiscoveryDocument myDiscoveryDocument =
          myProtocol.Discover("http://localhost/ContractReference/test_cs.disco");
      ArrayList myArrayList = (ArrayList)myDiscoveryDocument.References;

       // Get the ContractReference.
      ContractReference myContractRefrence = (ContractReference)myArrayList[0];

      // Get the DefaultFileName associated with the .disco file.
      String myFileName = myContractRefrence.DefaultFilename;

      // Get the URL associated with the .disco file.
      String myUrl = myContractRefrence.Url;
      Console.WriteLine("The DefaulFilename is: " + myUrl);
      Console.WriteLine("The URL is: " + myUrl);