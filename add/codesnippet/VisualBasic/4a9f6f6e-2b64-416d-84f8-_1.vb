      Console.WriteLine("Checking if message is AddHttpPostOut...")
      Dim myMessage As Message = myServiceDescription.Messages("AddHttpPostOut")
      If myMessageCollection.Contains(myMessage) Then

         ' Get the message part collection.
         Dim myMessagePartCollection As MessagePartCollection = myMessage.Parts

         ' Get the part named Body.
         Dim myMessagePart As MessagePart = myMessage.Parts("Body")
         If myMessagePartCollection.Contains(myMessagePart) Then

            ' Get the index of the part named Body.
            Console.WriteLine("Index of Body in MessagePart collection = " & _
               myMessagePartCollection.IndexOf(myMessagePart).ToString)
            Console.WriteLine("Deleting Body from MessagePart Collection...")
            myMessagePartCollection.Remove(myMessagePart)
            If myMessagePartCollection.IndexOf(myMessagePart) = -1 Then
               Console.WriteLine("MessagePart Body successfully deleted " & _
               "from the message AddHttpPostOut.")
            End If
         End If
      End If