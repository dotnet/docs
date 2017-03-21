      Message^ myMessage = gcnew Message;
      myMessage->Name = "AddSoapOut";
      MessagePart^ myMessagePart = gcnew MessagePart;
      myMessagePart->Name = "parameters";
      myMessagePart->Element = gcnew XmlQualifiedName( "AddResponse",myServiceDescription->TargetNamespace );
      myMessage->Parts->Add( myMessagePart );
      myServiceDescription->Messages->Add( myMessage );