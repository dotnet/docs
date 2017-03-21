      // Create a Port.
      Port^ postPort = gcnew Port;
      postPort->Name = "PortServiceHttpPost";
      postPort->Binding = gcnew XmlQualifiedName( "s0:PortServiceHttpPost" );