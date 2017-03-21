         Dim operationBindingArray(myOperationBindingCollection.Count -1  ) _
            As OperationBinding

         ' Copy this collection to the OperationBinding array.
         myOperationBindingCollection.CopyTo(operationBindingArray, 0)
         Console.WriteLine("The operations supported by this service " & _
            "are :")
         Dim myOperationBinding1 As OperationBinding
         For Each myOperationBinding1 In  operationBindingArray
            Dim myBinding As Binding = myOperationBinding1.Binding
            Console.WriteLine(" Binding : " & myBinding.Name & " Name of " & _
               "operation : " & myOperationBinding1.Name)
         Next myOperationBinding1