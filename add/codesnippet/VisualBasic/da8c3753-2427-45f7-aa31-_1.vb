         ' Display element properties in collection using 'Item' property.
         Dim i As Integer
         For i = 0 To myCollection.Count - 1
            Console.WriteLine(myCollection(i).TargetNamespace)
         Next i