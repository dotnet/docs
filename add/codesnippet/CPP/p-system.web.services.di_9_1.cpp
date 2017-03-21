   DiscoveryClientProtocol^ myProtocol = gcnew DiscoveryClientProtocol;
   
   // Get the DiscoveryDocument.
   DiscoveryDocument^ myDiscoveryDocument = myProtocol->Discover( "http://localhost/ContractReference/test_cs.disco" );
   ArrayList^ myArrayList = dynamic_cast<ArrayList^>(myDiscoveryDocument->References);
   
   // Get the ContractReference.
   ContractReference^ myContractRefrence = dynamic_cast<ContractReference^>(myArrayList[ 0 ]);
   
   // Get the DefaultFileName associated with the .disco file.
   String^ myFileName = myContractRefrence->DefaultFilename;
   
   // Get the URL associated with the .disco file.
   String^ myUrl = myContractRefrence->Url;
   Console::WriteLine( "The DefaulFilename is: {0}", myUrl );
   Console::WriteLine( "The URL is: {0}", myUrl );