         OperationMessage[] myCollection = 
            new OperationMessage[myOperationMessageCollection.Count];
         myOperationMessageCollection.CopyTo(myCollection, 0);
         Console.WriteLine("Operation name(s) :");
         for (int i = 0; i < myCollection.Length ; i++)
         {
            Console.WriteLine(" " + myCollection[i].Operation.Name);
         }
