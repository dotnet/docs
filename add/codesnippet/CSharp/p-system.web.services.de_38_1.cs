      // Get Message Collection.
      MessageCollection myMessageCollection = myServiceDescription.Messages;
      Console.WriteLine("Total Messages in the document = " + myServiceDescription.Messages.Count);
      Console.WriteLine("");
      Console.WriteLine("Enumerating Messages...");
      Console.WriteLine("");
      // Print messages to console.
      for(int i =0; i < myMessageCollection.Count; ++i)
      {
         Console.WriteLine("Message Name : " + myMessageCollection[i].Name);
      }