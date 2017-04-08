// System.Web.Services.Discovery.DiscoveryClientResultCollection
/*
The following example demonstrates 'DiscoveryClientResultCollection' class.
A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file
which contains the 'DiscoveryClientResult' objects, representing the details of 
discovery references. An element from the collection is removed and programmatically 
added to 'DiscoveryClientResultCollection' class.
*/
// <Snippet1>
using System;
using System.Reflection;
using System.IO;
using System.Web.Services.Discovery;
using System.Xml.Schema;
using System.Collections;

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
         Console.WriteLine(
             "Removing a DiscoveryClientResult from the collection...");

         // Remove the first DiscoveryClientResult from the collection.
         myDiscoveryClientResultCollection.Remove(
             myDiscoveryClientResultCollection[0]);
         Console.WriteLine("Adding a DiscoveryClientResult" +
             " to the collection...");
         DiscoveryClientResult myDiscoveryClientResult = 
             new DiscoveryClientResult();

         // Set the DiscoveryDocumentReference class as the type of 
         // reference in the discovery document.
         myDiscoveryClientResult.ReferenceTypeName = 
             "System.Web.Services.Discovery.DiscoveryDocumentReference";

         // Set the URL for the reference.
         myDiscoveryClientResult.Url = 
             "http://localhost/Discovery/Service1_cs.asmx?disco";

         // Set the name of the file in which the reference is saved.
         myDiscoveryClientResult.Filename = "Service1_cs.disco";

         // Add myDiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult);
         if(myDiscoveryClientResultCollection.Contains(myDiscoveryClientResult))
         {
            Console.WriteLine(
                "Instance of DiscoveryClientResult found in the Collection");
         }
      }
      catch(Exception ex)
      {
         Console.WriteLine("Error is "+ex.Message);
      }
   }
}
// </Snippet1>
