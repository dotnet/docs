      Service^ myService = gcnew Service;
      myService->Name = "MathService";
      XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:MathServiceSoap" );

      // Build a new Port for SOAP.
      Port^ mySoapPort = gcnew Port;
      mySoapPort->Name = "MathServiceSoap";
      mySoapPort->Binding = myXmlQualifiedName;
      SoapAddressBinding^ mySoapAddressBinding = gcnew SoapAddressBinding;
      mySoapAddressBinding->Location = "http://localhost/ServiceDescription_Read/AddService_CS.asmx";
      mySoapPort->Extensions->Add( mySoapAddressBinding );

      // Build a new Port for HTTP-GET.
      XmlQualifiedName^ myXmlQualifiedName2 = gcnew XmlQualifiedName( "s0:MathServiceHttpGet" );
      Port^ myHttpGetPort = gcnew Port;
      myHttpGetPort->Name = "MathServiceHttpGet";
      myHttpGetPort->Binding = myXmlQualifiedName2;
      HttpAddressBinding^ myHttpAddressBinding = gcnew HttpAddressBinding;
      myHttpAddressBinding->Location = "http://localhost/ServiceDescription_Read/AddService_CS.asmx";
      myHttpGetPort->Extensions->Add( myHttpAddressBinding );

      // Add the ports to the service.
      myService->Ports->Add( myHttpGetPort );
      myService->Ports->Add( mySoapPort );

      // Add the service to the ServiceCollection.
      myServiceDescription->Services->Insert( 1, myService );