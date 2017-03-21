         // Get the operation message for the Add operation.
         OperationMessage myOperationMessage =
            myOperationMessageCollection[0];
         OperationMessage myInputOperationMessage =
            (OperationMessage) new OperationInput();
         XmlQualifiedName myXmlQualifiedName = new XmlQualifiedName(
            "AddSoapIn", myDescription.TargetNamespace);
         myInputOperationMessage.Message = myXmlQualifiedName;

         OperationMessage[] myCollection = 
            new OperationMessage[myOperationMessageCollection.Count];
         myOperationMessageCollection.CopyTo(myCollection, 0);
         Console.WriteLine("Operation name(s) :");
         for (int i = 0; i < myCollection.Length ; i++)
         {
            Console.WriteLine(" " + myCollection[i].Operation.Name);
         }

         // Add the OperationMessage to the collection.
         myOperationMessageCollection.Add(myInputOperationMessage);
         DisplayFlowInputOutput(myOperationMessageCollection, "Add");

         if(myOperationMessageCollection.Contains(myOperationMessage) 
            == true )
         {
            int myIndex =
               myOperationMessageCollection.IndexOf(myOperationMessage);
            Console.WriteLine(" The index of the Add operation " +
               "message in the collection is : " + myIndex);
         }