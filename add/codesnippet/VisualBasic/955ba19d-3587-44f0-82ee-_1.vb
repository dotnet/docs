         If myOperationMessageCollection.Contains(myOperationMessage) _
            = True Then
            Dim myIndex As Integer = _
               myOperationMessageCollection.IndexOf(myOperationMessage)
            Console.WriteLine(" The index of the Add operation " & _
                "message in the collection is : " & myIndex.ToString())
         End If