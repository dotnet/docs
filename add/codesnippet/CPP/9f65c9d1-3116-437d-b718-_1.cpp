      // Initialize a new instance of the DiscoveryClientResult class.
      DiscoveryClientResult^ myDiscoveryClientResult =
         gcnew DiscoveryClientResult( System::Web::Services::Discovery::DiscoveryDocumentReference::typeid,
         "http://localhost/Discovery/Service1_cs.asmx?disco","Service1_cs.disco" );

      // Add the DiscoveryClientResult to the collection.
      myDiscoveryClientResultCollection->Add( myDiscoveryClientResult );