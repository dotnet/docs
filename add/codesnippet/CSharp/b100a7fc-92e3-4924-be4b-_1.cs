
      BindingCollection myBindingCollection = myServiceDescription.Bindings;
      Binding myBinding = myBindingCollection[0];
      OperationBindingCollection myOperationBindingCollection = myBinding.Operations;
      OperationBinding myOperationBinding = myOperationBindingCollection[0];
      FaultBindingCollection myFaultBindingCollection = myOperationBinding.Faults;

      // Reverse the fault bindings order.
      if(myFaultBindingCollection.Count > 1) 
      {
         FaultBinding myFaultBinding = myFaultBindingCollection[0];

         FaultBinding[] myFaultBindingArray = new FaultBinding[myFaultBindingCollection.Count];
         // Copy the fault bindings to a temporary array.
         myFaultBindingCollection.CopyTo(myFaultBindingArray, 0);

         // Remove all the fault binding instances in the fault binding collection.
         for(int i = 0; i < myFaultBindingArray.Length; i++)
            myFaultBindingCollection.Remove(myFaultBindingArray[i]);

         // Insert the fault binding instance in the reverse order.
         for(int i = 0, j = (myFaultBindingArray.Length - 1); i < myFaultBindingArray.Length; i++, j--)
            myFaultBindingCollection.Insert(i, myFaultBindingArray[j]);
         // Check if the first element in the collection before the reversal is now the last element.
         if(myFaultBindingCollection.Contains(myFaultBinding) && 
            myFaultBindingCollection.IndexOf(myFaultBinding) == (myFaultBindingCollection.Count - 1))
            // Display the WSDL generated to the console.
            myServiceDescription.Write(Console.Out);
         else
            Console.WriteLine("Error while reversing");
      }
