   // Creates a Message with name = messageName having one MessagePart 
   // with name = partName.
   public static Message CreateMessage(string messageName,string partName,
      string element,string targetNamespace)
   {
      Message myMessage = new Message();
      myMessage.Name = messageName;
      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = partName;
      myMessagePart.Element = new XmlQualifiedName(element,targetNamespace);
      myMessage.Parts.Add(myMessagePart);
      return myMessage;
   }