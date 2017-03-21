   DiscoveryClientProtocol^ myDiscoveryClientProtocol = gcnew DiscoveryClientProtocol;
   myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
   
   // 'dataservice.disco' is a sample discovery document.
   String^ myStringUrl = "http://localhost/dataservice.disco";
   
   // Call the Discover method to populate the References property.
   DiscoveryDocument^ myDiscoveryDocument = myDiscoveryClientProtocol->Discover( myStringUrl );
   
   // Resolve all references found in the discovery document.
   myDiscoveryClientProtocol->ResolveAll();
   DiscoveryClientReferenceCollection^ myDiscoveryClientReferenceCollection = myDiscoveryClientProtocol->References;
   
   // Retrieve the keys in the collection.
   ICollection^ myCollection = myDiscoveryClientReferenceCollection->Keys;
   array<Object^>^myObjectCollection = gcnew array<Object^>(myDiscoveryClientReferenceCollection->Count);
   myCollection->CopyTo( myObjectCollection, 0 );
   Console::WriteLine( "The discovery documents, service descriptions, and XML schema" );
   Console::WriteLine( " definitions in the collection are:" );
   for ( int iIndex = 0; iIndex < myObjectCollection->Length; iIndex++ )
   {
      Console::WriteLine( myObjectCollection[ iIndex ] );
   }