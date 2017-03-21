         ' Initialize a new instance of the DiscoveryClientResult class.
         Dim myDiscoveryClientResult As New DiscoveryClientResult( _
            GetType(System.Web.Services.Discovery.DiscoveryDocumentReference), _
            "http://localhost/Discovery/Service1_vb.asmx?disco", _
            "Service1_vb.disco")

         ' Add the DiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult)