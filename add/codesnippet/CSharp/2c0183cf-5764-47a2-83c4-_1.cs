            for(int i=0; i<myDiscoveryClientResultCollection.Count; i++)
            {
               DiscoveryClientResult myClientResult = 
                   myDiscoveryClientResultCollection[i];
               Console.WriteLine("DiscoveryClientResult "+(i+1));
               Console.WriteLine("Type of reference in the discovery document: "
                   + myClientResult.ReferenceTypeName);
               Console.WriteLine("Url for reference:" + myClientResult.Url);
               Console.WriteLine("File for saving the reference: "
                   + myClientResult.Filename);
            }