         Dim myDescription As New ServiceDescription()
         myDescription = ServiceDescription.Read("MyWsdl_VB.wsdl")
         myDescription.Name = "MyServiceDescription"
         Console.WriteLine("Name: " & myDescription.Name)
         Dim myMessageCollection As MessageCollection = myDescription.Messages
         
         ' Remove the message at index 0 from the message collection.
         myMessageCollection.Remove(myDescription.Messages(0))
         
         ' Build a new Message.
         Dim myMessage As New Message()
         myMessage.Name = "AddSoapIn"
         
         ' Build a new MessagePart.
         Dim myMessagePart As New MessagePart()
         myMessagePart.Name = "parameters"
         Dim myXmlQualifiedName As New XmlQualifiedName("s0:Add")
         myMessagePart.Element = myXmlQualifiedName
         
         ' Add MessageParts to the message.
         myMessage.Parts.Add(myMessagePart)

         ' Add the message to the ServiceDescription.
         myDescription.Messages.Add(myMessage)
         myDescription.Write("MyOutWsdl.wsdl")