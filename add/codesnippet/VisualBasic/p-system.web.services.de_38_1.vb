      ' Get Message Collection.
      Dim myMessageCollection As MessageCollection = myServiceDescription.Messages
      Console.WriteLine("Total Messages in the document = " + _
                              myServiceDescription.Messages.Count.ToString)
      Console.WriteLine("")
      Console.WriteLine("Enumerating Messages...")
      Console.WriteLine("")
      ' Print messages to console.
      Dim i As Integer
      For i = 0 To myMessageCollection.Count - 1
         Console.WriteLine("Message Name : " + myMessageCollection(i).Name)
      Next