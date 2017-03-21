         ' Copy elements of collection to an Object array.
         Dim myObjectArray2(myCollection.Count -1 ) As Object
         myCollection.CopyTo(myObjectArray2, 0)
         Console.WriteLine("Collection elements are copied to an object array.")