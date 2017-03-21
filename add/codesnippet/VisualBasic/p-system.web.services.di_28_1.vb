      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      myDiscoveryClientProtocol.Credentials = _
          CredentialCache.DefaultCredentials

      ' 'dataservice.disco' is a sample discovery document.
      Dim myStringUrl As String = "http://localhost/dataservice.disco"

      ' Call the Discover method to populate the References property.
      Dim myDiscoveryDocument As DiscoveryDocument = _
          myDiscoveryClientProtocol.Discover(myStringUrl)

      ' Resolve all references found in the discovery document.
      myDiscoveryClientProtocol.ResolveAll()
      Dim myDiscoveryClientReferenceCollection As DiscoveryClientReferenceCollection = _
          myDiscoveryClientProtocol.References

      ' Retrieve the keys in the collection.
      Dim myCollection As ICollection = myDiscoveryClientReferenceCollection.Keys
      Dim myObjectCollection(myDiscoveryClientReferenceCollection.Count) As Object
      myCollection.CopyTo(myObjectCollection, 0)

      Console.WriteLine("The discovery documents, service descriptions, and XML schema")
      Console.WriteLine(" definitions in the collection are:")
      Dim iIndex As Integer
      For iIndex = 0 To myObjectCollection.Length - 1
          Console.WriteLine(myObjectCollection(iIndex))
      Next iIndex