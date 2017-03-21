      MessagePart^ myMessagePart = gcnew MessagePart;
      myMessagePart->Name = "parameters";
      myMessagePart->Element = gcnew XmlQualifiedName( "AddResponse",myServiceDescription->TargetNamespace );
      myMessage->Parts->Add( myMessagePart );