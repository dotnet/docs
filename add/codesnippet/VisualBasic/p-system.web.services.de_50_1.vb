      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = partName
      myMessagePart.Element = New XmlQualifiedName(element, targetNamespace)
      myMessage.Parts.Add(myMessagePart)