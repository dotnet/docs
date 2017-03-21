      // Get Message by Name = "AddSoapIn".
      Message myMessage = myServiceDescription.Messages["AddSoapIn"];
      Console.WriteLine("");
      Console.WriteLine("Getting Message = 'AddSoapIn' {by Name}");
      if (myMessageCollection.Contains(myMessage))
      {
         Console.WriteLine("");
         // Get Message Name = "AddSoapIn" Index.
         Console.WriteLine("Message 'AddSoapIn' was found in Message Collection.");
         Console.WriteLine("Index of 'AddSoapIn' in Message Collection = " + myMessageCollection.IndexOf(myMessage));
         Console.WriteLine("Deleting Message from Message Collection...");
         myMessageCollection.Remove(myMessage);
         if(myMessageCollection.IndexOf(myMessage) == -1)
         {
            Console.WriteLine("Message 'AddSoapIn' was successfully removed from Message Collection.");
         }
      }