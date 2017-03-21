   // Creates a Message with name = messageName having one MessagePart
   // with name = partName.
public:
   static Message^ CreateMessage( String^ messageName, String^ partName, String^ element, String^ targetNamespace )
   {
      Message^ myMessage = gcnew Message;
      myMessage->Name = messageName;
      MessagePart^ myMessagePart = gcnew MessagePart;
      myMessagePart->Name = partName;
      myMessagePart->Element = gcnew XmlQualifiedName( element,targetNamespace );
      myMessage->Parts->Add( myMessagePart );
      return myMessage;
   }