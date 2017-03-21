      BindingCollection myBindingCollection = myServiceDescription.Bindings;
      Binding myBinding = myBindingCollection[0];
      OperationBindingCollection myOperationBindingCollection = myBinding.Operations;
      OperationBinding myOperationBinding = myOperationBindingCollection[0];
      FaultBindingCollection myFaultBindingCollection = myOperationBinding.Faults;
      if(myFaultBindingCollection.Contains(myFaultBindingCollection["ErrorString"]))
         myFaultBindingCollection.Remove(myFaultBindingCollection["ErrorString"]);