      Dim myLocalMessage As Message = _
         myServiceDescription.Messages("AddHttpPostOut")
      If myMessageCollection.Contains(myLocalMessage) Then
         Console.WriteLine("Message      : " & myLocalMessage.Name)

         ' Get the message part collection.
         Dim myMessagePartCollection As MessagePartCollection = _
            myLocalMessage.Parts
         Dim myMessagePart(myMessagePartCollection.Count) As MessagePart

         ' Copy the MessagePartCollection to an array.
         myMessagePartCollection.CopyTo(myMessagePart, 0)
         Dim k As Integer
         For k = 0 To myMessagePart.Length - 2
            Console.WriteLine(ControlChars.Tab & "       Part Name : " & _
               myMessagePartCollection(k).Name)
         Next k
         Console.WriteLine("")
      End If