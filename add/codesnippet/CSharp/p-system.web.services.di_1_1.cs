   class MyClass1
   {
      static void Main()
      {
         try
         {
            // Create the file stream.
            FileStream discoStream = 
                new FileStream("Service1_CS.disco",FileMode.Open);

            // Create the discovery document.
            DiscoveryDocument myDiscoveryDocument = 
                DiscoveryDocument.Read(discoStream);

            // Get the first ContractReference in the collection.
            ContractReference myContractReference =
                (ContractReference)myDiscoveryDocument.References[0];

            // Set the client protocol.
            myContractReference.ClientProtocol = new DiscoveryClientProtocol();
            myContractReference.ClientProtocol.Credentials = 
                CredentialCache.DefaultCredentials;

            // Get the service description.
            ServiceDescription myContract = myContractReference.Contract;

            // Create the service description file.
            myContract.Write("MyService1.wsdl");
            Console.WriteLine("The WSDL file created is MyService1.wsdl");

            discoStream.Close();
         }
         catch(Exception ex)
         {
            Console.WriteLine("Exception: " + ex.Message);
         }
      }
   }