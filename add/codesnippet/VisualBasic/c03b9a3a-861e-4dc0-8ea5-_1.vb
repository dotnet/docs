         Dim myCollection(myOperationMessageCollection.Count -1 ) _
            As OperationMessage
         myOperationMessageCollection.CopyTo(myCollection, 0)
         Console.WriteLine("Operation name(s) :")
         Dim i As Integer
         For i = 0 To myCollection.Length - 1
            Console.WriteLine(" " & myCollection(i).Operation.Name)
         Next i
