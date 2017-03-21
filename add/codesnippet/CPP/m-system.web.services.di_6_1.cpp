   // Call the constructor of the DiscoveryClientProtocol class.
   DiscoveryClientProtocol^ myDiscoveryClientProtocol =
      gcnew DiscoveryClientProtocol;
   myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
   // 'dataservice.disco' is a sample discovery document.
   String^ myStringUrl = "http://localhost:80/dataservice.disco";

   Stream^ myStream = myDiscoveryClientProtocol->Download( myStringUrl );

   Console::WriteLine( "Size of the discovery document downloaded" );
   Console::WriteLine( "is : {0} bytes", myStream->Length );
   myStream->Close();