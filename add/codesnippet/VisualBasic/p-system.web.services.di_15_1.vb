      ' 'Values' in the collection are retrieved.
      Dim myCollection1 As ICollection = myDiscoveryClientDocumentCollection.Values
      Dim myObjectCollection1(myDiscoveryClientDocumentCollection.Count-1) As Object
      myCollection1.CopyTo(myObjectCollection1, 0)
      Console.WriteLine("The objects in the collection are :")
      For iIndex = 0 To myObjectCollection1.Length - 1
         Console.WriteLine(myObjectCollection1(iIndex))
      Next iIndex 