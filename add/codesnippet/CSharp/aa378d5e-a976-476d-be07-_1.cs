         Console.WriteLine("Collection contains following types of elements: ");
         // Display the 'Type' of the elements in collection.
         for(int i = 0;i< myCollection.Count;i++) 
         {
            Console.WriteLine(myCollection[i].GetType().ToString()); 
         }