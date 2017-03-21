         myOperationCollection.Remove(myOperation);
         // Insert the 'myOpearation' operation at the index '0'.
         myOperationCollection.Insert(0, myOperation);
         Console.WriteLine("The operation at index '0' is : " +
                           myOperationCollection[0].Name);