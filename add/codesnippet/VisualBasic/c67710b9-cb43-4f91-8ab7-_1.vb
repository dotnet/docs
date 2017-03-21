         Dim myArray(myCollection.Count -1 ) As ServiceDescription
         ' Copy the collection to a 'ServiceDescription' array.
         myCollection.CopyTo(myArray, 0)
         Dim i As Integer
         For i = 0 To myArray.Length - 1
            Console.WriteLine("Name of element in array: " + myArray(i).Name)
         Next i