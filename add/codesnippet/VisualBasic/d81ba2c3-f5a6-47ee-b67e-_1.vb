      Dim myContains As Boolean = myDiscoveryClientDocumentCollection.Contains(myStringUrl)
      If myContains Then
         Console.WriteLine("The discovery document {0} is present in the Collection", _
                                                                              myStringUrl)
      End If