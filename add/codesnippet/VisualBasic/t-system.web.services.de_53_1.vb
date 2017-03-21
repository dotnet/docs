   ' Creates a Message with name = messageName having one MessagePart 
   ' with name = partName.
   Public Shared Function CreateMessage(messageName As String, _
      partName As String, element As String, targetNamespace As String) _
      As Message
      Dim myMessage As New Message()
      myMessage.Name = messageName
      Dim myMessagePart As New MessagePart()
      myMessagePart.Name = partName
      myMessagePart.Element = New XmlQualifiedName(element, targetNamespace)
      myMessage.Parts.Add(myMessagePart)
      Return myMessage
   End Function 'CreateMessage
   