         ' Initialize a new instance of the DiscoveryClientResult class.
         Dim myDiscoveryClientResult As New DiscoveryClientResult()

         ' Set the type of reference in the discovery document as 
         ' DiscoveryDocumentReference.
         myDiscoveryClientResult.ReferenceTypeName = _
             "System.Web.Services.Discovery.DiscoveryDocumentReference"

         ' Set the URL for the reference.
         myDiscoveryClientResult.Url = _
             "http://localhost/Discovery/Service1_vb.asmx?disco"

         ' Set the name of the file in which the reference is saved.
         myDiscoveryClientResult.Filename = "Service1_vb.disco"

         ' Add the DiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult)