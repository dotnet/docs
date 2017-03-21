      Message myMessage = new Message();
      myMessage.Name = "AddSoapOut";
      MessagePart myMessagePart = new MessagePart();
      myMessagePart.Name = "parameters";
      myMessagePart.Element = new 
         XmlQualifiedName("AddResponse",myServiceDescription.TargetNamespace);
      myMessage.Parts.Add(myMessagePart);
      myServiceDescription.Messages.Add(myMessage);