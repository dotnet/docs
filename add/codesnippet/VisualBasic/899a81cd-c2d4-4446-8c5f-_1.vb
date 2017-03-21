      ' Get Message by Name = "AddSoapIn".
      Dim myMessage As Message = myServiceDescription.Messages("AddSoapIn")
      Console.WriteLine("")
      Console.WriteLine("Getting Message = 'AddSoapIn' {by Name}")
      If myMessageCollection.Contains(myMessage) Then
         Console.WriteLine("")
         ' Get Message Name = "AddSoapIn" Index.
         Console.WriteLine("Message 'AddSoapIn' was found in Message Collection.")
         Console.WriteLine("Index of 'AddSoapIn' in Message Collection = " + _
                           myMessageCollection.IndexOf(myMessage).ToString)
         Console.WriteLine("Deleting Message from Message Collection...")
         myMessageCollection.Remove(myMessage)
         If myMessageCollection.IndexOf(myMessage) = -1 Then
            Console.WriteLine("Message 'AddSoapIn' was successfully " + _
                              " removed from Message Collection.")
         End If
      End If