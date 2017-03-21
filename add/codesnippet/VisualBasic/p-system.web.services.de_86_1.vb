         ' Get the OperationBinding of the Add operation from the collection.
         Dim myOperationBinding As OperationBinding = _
            myOperationBindingCollection(3)

         ' Remove the OperationBinding of the 'Add' operation from
         ' the collection.
         myOperationBindingCollection.Remove(myOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Removed the OperationBinding of the " & _
            "Add operation from the collection.")