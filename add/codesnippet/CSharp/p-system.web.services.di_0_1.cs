            // Initialize new instance of the DiscoveryClientResult class.
            DiscoveryClientResult myDiscoveryClientResult =
                new DiscoveryClientResult();

            // Set the type of reference in the discovery document as 
            // DiscoveryDocumentReference.
            myDiscoveryClientResult.ReferenceTypeName = 
                "System.Web.Services.Discovery.DiscoveryDocumentReference";

            // Set the URL for the reference.
            myDiscoveryClientResult.Url = 
                "http://localhost/Discovery/Service1_cs.asmx?disco";

            // Set the name of the file in which the reference is saved.
            myDiscoveryClientResult.Filename = "Service1_cs.disco";

            // Add the DiscoveryClientResult to the collection.
            myDiscoveryClientResultCollection.Add(myDiscoveryClientResult);