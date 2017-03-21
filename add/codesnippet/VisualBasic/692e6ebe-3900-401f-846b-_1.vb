            ' Get the index of 'ServiceDescription' object.
            Dim myIndex As Integer = myCollection.IndexOf(myServiceDescription2)
            ' Remove 'ServiceDescription' object from the collection.
            myCollection.Remove(myServiceDescription2)
            Console.WriteLine("Element at index {0} is removed ", myIndex.ToString())