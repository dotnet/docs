      ICollection myCollection = myDiscoveryClientDocumentCollection.Keys;
      object[] myObjectCollection = 
                     new object[myDiscoveryClientDocumentCollection.Count];
      myCollection.CopyTo(myObjectCollection, 0);
      Console.WriteLine("The discovery documents in the collection are :");
      for (int iIndex=0; iIndex < myObjectCollection.Length; iIndex++)
      {
         Console.WriteLine(myObjectCollection[iIndex]);
      }