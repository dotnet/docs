         ' Check for the Add OperationBinding in the collection.
         Dim contains As Boolean = _
            myOperationBindingCollection.Contains(addOperationBinding)
         Console.WriteLine(ControlChars.NewLine & _
            "Whether the collection contains the Add " & _
            "OperationBinding : " & contains.ToString())