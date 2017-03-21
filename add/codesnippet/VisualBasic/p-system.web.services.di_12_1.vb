      Dim myCollection As ICollection = myDiscoveryClientDocumentCollection.Keys
      Dim myObjectCollection(myDiscoveryClientDocumentCollection.Count-1) As Object
      myCollection.CopyTo(myObjectCollection, 0)
      Console.WriteLine("The discovery documents in the collection are :")
      Dim iIndex As Integer
      For iIndex = 0 To myObjectCollection.Length - 1
         Console.WriteLine(myObjectCollection(iIndex))
      Next iIndex