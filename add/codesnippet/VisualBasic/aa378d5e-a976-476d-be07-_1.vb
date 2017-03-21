         Console.WriteLine("Collection contains following types of elements: ")
         ' Display the 'Type' of the elements in collection.
         Dim i As Integer
         For i = 0 To myCollection.Count - 1
            Console.WriteLine(myCollection(i).GetType().ToString())
         Next i