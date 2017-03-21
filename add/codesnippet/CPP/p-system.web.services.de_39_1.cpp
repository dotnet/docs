   ServiceDescription^ myDescription = gcnew ServiceDescription;
   myDescription = ServiceDescription::Read( "MyWsdl_CS.wsdl" );
   myDescription->Name = "MyServiceDescription";
   Console::WriteLine( "Name: {0}", myDescription->Name );
   MessageCollection^ myMessageCollection = myDescription->Messages;

   // Remove the message at index 0 from the message collection.
   myMessageCollection->Remove( myDescription->Messages[ 0 ] );

   // Build a new message.
   Message^ myMessage = gcnew Message;
   myMessage->Name = "AddSoapIn";

   // Build a new MessagePart.
   MessagePart^ myMessagePart = gcnew MessagePart;
   myMessagePart->Name = "parameters";
   XmlQualifiedName^ myXmlQualifiedName = gcnew XmlQualifiedName( "s0:Add" );
   myMessagePart->Element = myXmlQualifiedName;

   // Add MessageParts to the message.
   myMessage->Parts->Add( myMessagePart );

   // Add the message to the ServiceDescription.
   myDescription->Messages->Add( myMessage );
   myDescription->Write( "MyOutWsdl.wsdl" );