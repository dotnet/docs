      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = "parameters";
      myMessagePart.Element = new 
         XmlQualifiedName("AddResponse",myServiceDescription.TargetNamespace);
      myMessage.Parts.Add(myMessagePart);