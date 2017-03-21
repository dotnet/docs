         Operation[] myOperationArray = new Operation[
                                             myOperationCollection.Count];
         myOperationCollection.CopyTo(myOperationArray, 0);
         Console.WriteLine("The operation(s) in the collection are :");
         for(int i = 0; i < myOperationCollection.Count; i++)
         {
            Console.WriteLine(" " + myOperationArray[i].Name);
         }