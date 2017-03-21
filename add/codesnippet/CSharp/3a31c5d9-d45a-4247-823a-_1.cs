      Message myMessage1 = new Message();
      myMessage1.Name = "AddSoapIn";
      MessagePart myMessagePart1 = new MessagePart();
      myMessagePart1.Name = "parameters";
      myMessagePart1.Element = new XmlQualifiedName("Add",myServiceDescription.TargetNamespace);
      myMessage1.Parts.Insert(0,myMessagePart1);
      myServiceDescription.Messages.Insert(16,myMessage1);