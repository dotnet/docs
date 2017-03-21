         // Check for 'ServiceDescription' object in the collection.
         if (myCollection.Contains(myServiceDescription2))
         { 
            // Get the index of 'ServiceDescription' object.
            int myIndex = myCollection.IndexOf(myServiceDescription2); 
            // Remove 'ServiceDescription' object from the collection.
            myCollection.Remove(myServiceDescription2);
            Console.WriteLine("Element at index {0} is removed ", myIndex);
         }
         else
         {
            Console.WriteLine("Element not found.");
         }