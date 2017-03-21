         ' Insert the OperationBinding of the Add operation at index 0.
         myOperationBindingCollection.Insert(0, addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Inserted the OperationBinding of the " & _
            "Add operation in the collection.")

         ' Get the index of the OperationBinding of the Add
         ' operation from the collection.
         Dim index As Integer = myOperationBindingCollection.IndexOf( _
            addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "The index of the OperationBinding of the " & _
            "Add operation : " & index.ToString())