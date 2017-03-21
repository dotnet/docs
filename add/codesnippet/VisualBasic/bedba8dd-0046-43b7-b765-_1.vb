      Dim myStringUrl1 As String = "http://localhost/dataservice.disco"
      If myDiscoveryClientReferenceCollection.Contains(myStringUrl1) Then
          Console.WriteLine("The document reference {0} is part of the" + _
          " collection.", myStringUrl1)
      End If