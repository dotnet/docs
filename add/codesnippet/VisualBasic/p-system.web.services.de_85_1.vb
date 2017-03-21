      ' Create OperationBindings for each of the operations defined in asmx file.
      Dim addOperationBinding As OperationBinding = CreateOperationBinding("Add", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(addOperationBinding)
      Dim subtractOperationBinding As OperationBinding = CreateOperationBinding("Subtract", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(subtractOperationBinding)
      Dim multiplyOperationBinding As OperationBinding = CreateOperationBinding("Multiply", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(multiplyOperationBinding)
      Dim divideOperationBinding As OperationBinding = CreateOperationBinding("Divide", myServiceDescription.TargetNamespace)
      myBinding.Operations.Add(divideOperationBinding)