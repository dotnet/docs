   DiscoveryClientReferenceCollection^ myDiscoveryClientReferenceCollection = gcnew DiscoveryClientReferenceCollection;
   ContractReference^ myContractReference = gcnew ContractReference;
   String^ myStringUrl1 = "http://www.contoso.com/service1.disco";
   myContractReference->Ref = myStringUrl1;
   myDiscoveryClientReferenceCollection->Add( myContractReference );

   // myDiscoveryClientReferenceCollection is an instance collection.
   Object^ myObject = myDiscoveryClientReferenceCollection[ myStringUrl1 ];
   Console::WriteLine( "Object representing the URL: {0}", myObject );