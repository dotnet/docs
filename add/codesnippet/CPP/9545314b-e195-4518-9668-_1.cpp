      // Insert the OperationBinding of the Add operation at index 0.
      myOperationBindingCollection->Insert( 0, addOperationBinding );
      Console::WriteLine( "\nInserted the OperationBinding of the "
      "Add operation in the collection." );

      // Get the index of the OperationBinding of the Add
      // operation from the collection.
      int index = myOperationBindingCollection->IndexOf( addOperationBinding );
      Console::WriteLine( "\nThe index of the OperationBinding of the Add operation : {0}", index );