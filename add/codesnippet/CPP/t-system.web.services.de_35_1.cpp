      ServiceDescription^ myServiceDescription = ServiceDescription::Read( "MathService_input_cpp.wsdl" );
      // Create SOAP messages.
      Message^ myMessage = gcnew Message;
      myMessage->Name = "AddSoapOut";
      MessagePart^ myMessagePart = gcnew MessagePart;
      myMessagePart->Name = "parameters";
      myMessagePart->Element = gcnew XmlQualifiedName( "AddResponse",myServiceDescription->TargetNamespace );
      myMessage->Parts->Add( myMessagePart );
      myServiceDescription->Messages->Add( myMessage );