      MessagePart^ myMessagePart = gcnew MessagePart;
      myMessagePart->Name = partName;
      myMessagePart->Element = gcnew XmlQualifiedName( element,targetNamespace );
      myMessage->Parts->Add( myMessagePart );