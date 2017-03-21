            // Get the index of 'ServiceDescription' object.
            int myIndex = myCollection.IndexOf(myServiceDescription2); 
            // Remove 'ServiceDescription' object from the collection.
            myCollection.Remove(myServiceDescription2);
            Console.WriteLine("Element at index {0} is removed ", myIndex);