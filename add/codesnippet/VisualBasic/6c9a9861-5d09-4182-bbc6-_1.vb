      ' Create a Message Array.
      Dim myMessages(myServiceDescription.Messages.Count) As Message
      ' Copy MessageCollection to an array.
      myServiceDescription.Messages.CopyTo(myMessages, 0)
      Console.WriteLine("")
      Console.WriteLine("Displaying Messages that were copied to Messagearray ...")
      Console.WriteLine("")
      For i = 0 To myMessageCollection.Count - 1
         Console.WriteLine("Message Name : " + myMessages(i).Name)
      Next