      Dim myServiceDescription As ServiceDescription = _
         ServiceDescription.Read ("MathService_input_vb.wsdl")

      ' Create SOAP messages.
      Dim myMessage As New Message()
      myMessage.Name = "AddSoapOut"
      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = "parameters"
      myMessagePart.Element = New XmlQualifiedName("AddResponse", _
         myServiceDescription.TargetNamespace)
      myMessage.Parts.Add(myMessagePart)
      myServiceDescription.Messages.Add(myMessage)