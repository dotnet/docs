         // Get the OperationBinding of the Add operation from the collection.
         OperationBinding myOperationBinding = 
            myOperationBindingCollection[3];

         // Remove the OperationBinding of the Add operation from 
         // the collection.
         myOperationBindingCollection.Remove(myOperationBinding);
         Console.WriteLine("\nRemoved the OperationBinding of the " +
            "Add operation from the collection.");