      Dim myBindingCollection As BindingCollection = myServiceDescription.Bindings
      Dim myBinding As Binding = myBindingCollection(0)
      Dim myOperationBindingCollection As OperationBindingCollection = myBinding.Operations
      Dim myOperationBinding As OperationBinding = myOperationBindingCollection(0)
      Dim myFaultBindingCollection As FaultBindingCollection = myOperationBinding.Faults
      If myFaultBindingCollection.Contains(myFaultBindingCollection("ErrorString")) Then
         myFaultBindingCollection.Remove(myFaultBindingCollection("ErrorString"))
        End If