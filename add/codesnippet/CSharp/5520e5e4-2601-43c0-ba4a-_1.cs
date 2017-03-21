         // Copy elements of collection to an Object array.
         Object[] myObjectArray2 = new Object[myCollection.Count];
         myCollection.CopyTo(myObjectArray2,0);
         Console.WriteLine("Collection elements are copied to an object array.");