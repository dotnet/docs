// System.Web.Services.Discovery.DiscoveryClientResultCollection.Remove
// System.Web.Services.Discovery.DiscoveryClientResult()
// System.Web.Services.Discovery.DiscoveryClientResult.ReferenceTypeName
// System.Web.Services.Discovery.DiscoveryClientResult.Url
// System.Web.Services.Discovery.DiscoveryClientResult.Filename
// System.Web.Services.Discovery.DiscoveryClientResultCollection.Add
// System.Web.Services.Discovery.DiscoveryClientResultCollection.Contains
// System.Web.Services.Discovery.DiscoveryClientResultCollection.Item
/*
The following example demonstrates 'ReferenceTypeName' ,'Url','Filename' properties and the 
constructor of 'DiscoveryClientResult' class  and 'Remove', 'Add' 'Contains' methods and 
'Item' property of 'DiscoveryClientResultCollection' class.
A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file 
which contains the 'DiscoveryClientResult' objects, representing the details of
discovery references. An element from the collection is removed and programmatically 
added to it to show the usage of methods of 'DiscoveryClientResultCollection' class . 
The contents of this collection are displayed..
*/

using System;
using System.Web.Services.Discovery;

   public class MyDiscoveryClientResult
   {
      static void Main()
      {
         try
         {
            DiscoveryClientProtocol myDiscoveryClientProtocol = 
               new DiscoveryClientProtocol();

            // Get the collection of DiscoveryClientResult objects.
            DiscoveryClientResultCollection myDiscoveryClientResultCollection = 
                myDiscoveryClientProtocol.ReadAll("results.discomap");

            Console.WriteLine("The number of DiscoveryClientResult objects: "
                + myDiscoveryClientResultCollection.Count);

            Console.WriteLine(
                "Removing a DiscoveryClientResult from the collection...");
// <Snippet1>
            // Remove the first DiscoveryClientResult from the collection.
            myDiscoveryClientResultCollection.Remove(
                myDiscoveryClientResultCollection[0]);
// </Snippet1>
            Console.WriteLine(
                "Adding a DiscoveryClientResult to the collection...");
// <Snippet2>
// <Snippet3>
// <Snippet4>
// <Snippet5>
// <Snippet6>
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
// </Snippet6>
// </Snippet5>
// </Snippet4>
// </Snippet3>
// </Snippet2>

// <Snippet7>
            if(myDiscoveryClientResultCollection.Contains(
                myDiscoveryClientResult))
            {
                Console.WriteLine(
                    "The collection contains the specified " +
                    "DiscoveryClientResult instance.");
            }
// </Snippet7>
            Console.WriteLine("Displaying the items in collection");

// <Snippet8>
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
// </Snippet8>
         }
         catch(Exception e)
         {
            Console.WriteLine("Error is "+e.Message);
         }
      }
   }

