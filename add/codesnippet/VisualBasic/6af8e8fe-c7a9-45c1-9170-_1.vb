         Dim myUrl As String = "http://localhost/Sample_vb.vsdisco"
         Dim myProtocol As New DiscoveryClientProtocol()
         Dim myReference As New DiscoveryDocumentReference(myUrl)
         Dim myFileStream As Stream = myProtocol.Download(myUrl)
         Dim myDiscoveryDocument As DiscoveryDocument = _
                 CType(myReference.ReadDocument(myFileStream), DiscoveryDocument)