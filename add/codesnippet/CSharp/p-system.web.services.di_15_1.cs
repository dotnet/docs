      // 'Values' in the collection are retrieved.
      ICollection myCollection1 = myDiscoveryClientDocumentCollection.Values;
      object[] myObjectCollection1 = 
                     new object[myDiscoveryClientDocumentCollection.Count];
      myCollection1.CopyTo(myObjectCollection1, 0);
      Console.WriteLine("The objects in the collection are :");
      for (int iIndex=0; iIndex < myObjectCollection1.Length; iIndex++)
         Console.WriteLine(myObjectCollection1[iIndex]);