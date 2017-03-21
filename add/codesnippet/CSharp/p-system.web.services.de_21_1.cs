      // Get the message part collection for each message.
      for(int i =0; i < myMessageCollection.Count; ++i)
      {
         Console.WriteLine("Message      : " + myMessageCollection[i].Name);

         // Get the message part collection.
         MessagePartCollection myMessagePartCollection = 
            myMessageCollection[i].Parts;

         // Display the part collection.
         for(int k = 0; k < myMessagePartCollection.Count;k++)
         {
            Console.WriteLine("\t       Part Name     : " + 
               myMessagePartCollection[k].Name);
            Console.WriteLine("\t       Message Name  : " + 
               myMessagePartCollection[k].Message.Name);
         }
         Console.WriteLine("");
      }