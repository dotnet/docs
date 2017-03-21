
      Dim myDiscoveryClientReferenceCollection As _
          New DiscoveryClientReferenceCollection()

      Dim myContractReference As New ContractReference()
      Dim myStringUrl1 As String = "http://www.contoso.com/service1.disco"
      myContractReference.Ref = myStringUrl1
      myDiscoveryClientReferenceCollection.Add(myContractReference)
      ' myDiscoveryClientReferenceCollection is an instance collection.
      Dim myObject As Object = _
          myDiscoveryClientReferenceCollection.Item(myStringUrl1)
      Console.WriteLine("Object representing the URL: " + myObject.ToString())