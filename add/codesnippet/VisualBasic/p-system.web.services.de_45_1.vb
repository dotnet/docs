         ' Get the operation message for the Add operation.
         Dim myOperationMessage As OperationMessage = _
            myOperationMessageCollection.Item(0)
         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As _
            New XmlQualifiedName("AddSoapIn", myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName
         
         Dim myCollection(myOperationMessageCollection.Count -1 ) _
            As OperationMessage
         myOperationMessageCollection.CopyTo(myCollection, 0)
         Console.WriteLine("Operation name(s) :")
         Dim i As Integer
         For i = 0 To myCollection.Length - 1
            Console.WriteLine(" " & myCollection(i).Operation.Name)
         Next i

         ' Add the OperationMessage to the collection.
         myOperationMessageCollection.Add(myInputOperationMessage)
         DisplayFlowInputOutput(myOperationMessageCollection, "Add")
         
         If myOperationMessageCollection.Contains(myOperationMessage) _
            = True Then
            Dim myIndex As Integer = _
               myOperationMessageCollection.IndexOf(myOperationMessage)
            Console.WriteLine(" The index of the Add operation " & _
                "message in the collection is : " & myIndex.ToString())
         End If