      Dim myMessage1 As New Message()
      myMessage1.Name = "AddSoapIn"
      Dim myMessagePart1 As New MessagePart()
      myMessagePart1.Name = "parameters"
      myMessagePart1.Element = New XmlQualifiedName("Add", _
         myServiceDescription.TargetNamespace)
      myMessage1.Parts.Insert(0, myMessagePart1)
      myServiceDescription.Messages.Insert(16, myMessage1)