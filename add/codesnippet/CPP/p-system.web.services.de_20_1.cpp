      // Create a Port.
      Port^ postPort = gcnew Port;
      postPort->Name = "PortServiceHttpPost";
      postPort->Binding = gcnew XmlQualifiedName( "s0:PortServiceHttpPost" );

      // Create an HttpAddressBinding.
      HttpAddressBinding^ postAddressBinding = gcnew HttpAddressBinding;
      postAddressBinding->Location = "http://localhost/PortClass/PortService_cs.asmx";

      // Add the HttpAddressBinding to the Port.
      postPort->Extensions->Add( postAddressBinding );