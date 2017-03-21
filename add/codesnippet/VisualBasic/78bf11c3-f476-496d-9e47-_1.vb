         Dim myOperationArray(myOperationCollection.Count) As Operation
         myOperationCollection.CopyTo(myOperationArray, 0)
         Console.WriteLine("The operation(s) in the collection are :")
         Dim i As Integer
         For i = 0 To myOperationCollection.Count - 1
            Console.WriteLine(" " + myOperationArray(i).Name)
         Next i