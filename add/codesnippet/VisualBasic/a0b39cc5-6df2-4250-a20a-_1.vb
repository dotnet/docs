      Dim myDiscoveryClientDocumentCollection As New DiscoveryClientDocumentCollection()
      Dim myDiscoveryDocument As New DiscoveryDocument()
      Dim myStringUrl As String = "http://www.contoso.com/service.disco"
      Dim myStringUrl1 As String = "http://www.contoso.com/service1.disco"
      
      myDiscoveryClientDocumentCollection.Add(myStringUrl, myDiscoveryDocument)
      myDiscoveryClientDocumentCollection.Add(myStringUrl1, myDiscoveryDocument)
      myDiscoveryClientDocumentCollection.Remove(myStringUrl1)