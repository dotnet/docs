      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = "parameters"
      myMessagePart.Element = New XmlQualifiedName("AddResponse", _
         myServiceDescription.TargetNamespace)
      myMessage.Parts.Add(myMessagePart)