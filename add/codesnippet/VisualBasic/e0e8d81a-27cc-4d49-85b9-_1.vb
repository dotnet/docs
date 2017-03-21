         myOperationMessageCollection.Remove(myInputOperationMessage)

         ' Display Flow, Input, and Output after removing.
         DisplayFlowInputOutput(myOperationMessageCollection, "Remove")

         ' Insert the message at index 0 in the collection.
         myOperationMessageCollection.Insert(0, myInputOperationMessage)

         ' Display Flow, Input, and Output after inserting.
         DisplayFlowInputOutput(myOperationMessageCollection, "Insert")
