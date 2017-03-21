      MessagePart^ myMessagePart1 = gcnew MessagePart;
      myMessagePart1->Name = "parameters";
      myMessagePart1->Element = gcnew XmlQualifiedName( "Add",myServiceDescription->TargetNamespace );
      myMessage1->Parts->Insert( 0, myMessagePart1 );