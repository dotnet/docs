      Message myLocalMessage = myServiceDescription.Messages["AddHttpPostOut"];
      if (myMessageCollection.Contains(myLocalMessage))
      {
         Console.WriteLine("Message      : " + myLocalMessage.Name);

         // Get the message part collection.
         MessagePartCollection myMessagePartCollection = myLocalMessage.Parts;
         MessagePart[] myMessagePart  = 
            new MessagePart[myMessagePartCollection.Count];

         // Copy the MessagePartCollection to an array.
         myMessagePartCollection.CopyTo(myMessagePart,0);
         for(int k = 0; k < myMessagePart.Length; k++)
         {
            Console.WriteLine("\t       Part Name : " + 
               myMessagePartCollection[k].Name);
         }
         Console.WriteLine("");
      }