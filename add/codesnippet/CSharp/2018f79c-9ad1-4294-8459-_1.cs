         OperationBinding[] operationBindingArray = new
            OperationBinding[myOperationBindingCollection.Count];

         // Copy this collection to the OperationBinding array.
         myOperationBindingCollection.CopyTo(operationBindingArray, 0);
         Console.WriteLine("The operations supported by this service " +
            "are :");
         foreach(OperationBinding myOperationBinding1 in 
            operationBindingArray)
         {
            Binding myBinding = myOperationBinding1.Binding;
            Console.WriteLine(" Binding : "+ myBinding.Name + " Name of " +
               "operation : " + myOperationBinding1.Name);
         }