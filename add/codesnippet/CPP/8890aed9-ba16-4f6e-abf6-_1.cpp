      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_CS.wsdl" );
      PortTypeCollection^ myPortTypeCollection = myServiceDescription->PortTypes;
      int noOfPortTypes = myServiceDescription->PortTypes->Count;
      Console::WriteLine( "\nTotal number of PortTypes: {0}", myServiceDescription->PortTypes->Count );

      // Get the first PortType in the collection.
      PortType^ myNewPortType = myPortTypeCollection[ 0 ];
      Console::WriteLine( "The PortType at index 0 is: {0}", myNewPortType->Name );
      Console::WriteLine( "Removing the PortType {0}", myNewPortType->Name );

      // Remove the PortType from the collection.
      myPortTypeCollection->Remove( myNewPortType );

      // Display the number of PortTypes.
      Console::WriteLine( "\nTotal number of PortTypes after removing: {0}", myServiceDescription->PortTypes->Count );
      Console::WriteLine( "Adding a PortType {0}", myNewPortType->Name );

      // Add a new PortType from the collection.
      myPortTypeCollection->Add( myNewPortType );

      // Display the number of PortTypes after adding a port.
      Console::WriteLine( "Total number of PortTypes after adding a new port: {0}", myServiceDescription->PortTypes->Count );
      myServiceDescription->Write( "MathService_New.wsdl" );