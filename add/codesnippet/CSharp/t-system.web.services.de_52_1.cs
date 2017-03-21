      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = partName;
      myMessagePart.Element = new XmlQualifiedName(element,targetNamespace);
      myMessage.Parts.Add(myMessagePart);