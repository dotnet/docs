      // Create OperationBindings for each of the operations defined in asmx file.
      OperationBinding^ addOperationBinding = CreateOperationBinding( "Add", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( addOperationBinding );
      OperationBinding^ subtractOperationBinding = CreateOperationBinding( "Subtract", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( subtractOperationBinding );
      OperationBinding^ multiplyOperationBinding = CreateOperationBinding( "Multiply", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( multiplyOperationBinding );
      OperationBinding^ divideOperationBinding = CreateOperationBinding( "Divide", myServiceDescription->TargetNamespace );
      myBinding->Operations->Add( divideOperationBinding );