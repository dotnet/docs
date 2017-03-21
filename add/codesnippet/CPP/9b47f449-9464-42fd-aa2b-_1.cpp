      // Create a new Binding for SOAP Protocol.
      Binding^ myBinding = gcnew Binding;
      myBinding->Name = String::Concat( myServiceDescription->Services->default[ 0 ]->Name, "Soap" );

      // Pass the name of the existing porttype 'MathServiceSoap' and the Xml targetNamespace attribute of the Descriptions tag.
      myBinding->Type = gcnew XmlQualifiedName( "MathServiceSoap",myServiceDescription->TargetNamespace );

      // Create SOAP Extensibility element.
      SoapBinding^ mySoapBinding = gcnew SoapBinding;
      // SOAP over HTTP.
      mySoapBinding->Transport = "http://schemas.xmlsoap.org/soap/http";
      mySoapBinding->Style = SoapBindingStyle::Document;
      // Add tag soap:binding as an extensibility element.
      myBinding->Extensions->Add( mySoapBinding );

      // Create OperationBindings for each of the operations defined in asmx file.
      OperationBinding^ addOperationBinding = CreateOperationBinding( "Add", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( addOperationBinding );
      OperationBinding^ subtractOperationBinding = CreateOperationBinding( "Subtract", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( subtractOperationBinding );
      OperationBinding^ multiplyOperationBinding = CreateOperationBinding( "Multiply", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( multiplyOperationBinding );
      OperationBinding^ divideOperationBinding = CreateOperationBinding( "Divide", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( divideOperationBinding );

      myServiceDescription->Bindings->Insert( 0, myBinding );