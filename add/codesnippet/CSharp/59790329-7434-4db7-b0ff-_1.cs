      Console.WriteLine("Checking if message is AddHttpPostOut...");
      Message myMessage = myServiceDescription.Messages["AddHttpPostOut"];
      if (myMessageCollection.Contains(myMessage))
      {
         // Get the message part collection.
         MessagePartCollection myMessagePartCollection = myMessage.Parts;

         // Get the part named Body.
         MessagePart myMessagePart = myMessage.Parts["Body"];
         if (myMessagePartCollection.Contains(myMessagePart))
         {
            // Get the index of the part named Body.
            Console.WriteLine("Index of Body in MessagePart collection = " + 
               myMessagePartCollection.IndexOf(myMessagePart));
            Console.WriteLine("Deleting Body from MessagePart collection...");
            myMessagePartCollection.Remove(myMessagePart);
            if(myMessagePartCollection.IndexOf(myMessagePart)== -1)
            {
               Console.WriteLine("MessagePart Body successfully deleted " +
                  "from the message AddHttpPostOut.");
            }
         }
      }