      // Create a Message Array.
      Message[] myMessages = new Message[myServiceDescription.Messages.Count];
      // Copy MessageCollection to an array.
      myServiceDescription.Messages.CopyTo(myMessages,0);
      Console.WriteLine("");
      Console.WriteLine("Displaying Messages that were copied to Messagearray ...");
      Console.WriteLine("");
      for(int i=0;i < myServiceDescription.Messages.Count; ++i)
      {
         Console.WriteLine("Message Name : " + myMessages[i].Name);
      }