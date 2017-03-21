      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", noOfPortTypes );
      PortType^ myNewPortType = myPortTypeCollection[ "MathServiceSoap" ];

      // Get the index in the collection.
      int index = myPortTypeCollection->IndexOf( myNewPortType );

      Console::WriteLine( "Removing the PortType named {0}", myNewPortType->Name );
      
      // Remove the PortType from the collection.
      myPortTypeCollection->Remove( myNewPortType );
      noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", noOfPortTypes );

      // Check whether the PortType exists in the collection.
      bool bContains = myPortTypeCollection->Contains( myNewPortType );
      Console::WriteLine( "Port Type'{0}' exists: {1}", myNewPortType->Name, bContains );
      Console::WriteLine( "Adding the PortType" );

      // Insert a new portType at the index location.
      myPortTypeCollection->Insert( index, myNewPortType );