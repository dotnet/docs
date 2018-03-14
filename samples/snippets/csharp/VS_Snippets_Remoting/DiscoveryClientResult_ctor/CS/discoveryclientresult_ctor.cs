// System.Web.Services.Discovery.DiscoveryClientResult(Type,String,String)

/*
The following example demonstrates the DiscoveryClientResult(Type,String,String)
constructor of 'DiscoveryClientResult' class.
A 'DiscoveryClientResultCollection' object is obtained by reading a '.discomap' file 
which contains the 'DiscoveryClientResult' objects, representing the details of 
discovery references. A 'DiscoveryClientProtocol' object from the collection is 
removed. Then a 'DiscoveryClientProtocol' is created suppling the type of reference
in the discovery document, URL for the reference and  name of the file in which the
reference is saved.and programmatically added to it. The contents of this collection 
are displayed.
*/

using System;
using System.Reflection;
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
         Console.WriteLine("Removing a DiscoveryClientResult "
            + "from the collection...");

         // Remove first DiscoveryClientResult from the collection.
         myDiscoveryClientResultCollection.Remove
                  (myDiscoveryClientResultCollection[0]);
         Console.WriteLine("Adding a DiscoveryClientResult "
            + "to the collection...");
// <Snippet1>
         // Initialize a new instance of the DiscoveryClientResult class.
         DiscoveryClientResult myDiscoveryClientResult = 
            new DiscoveryClientResult(
            typeof(System.Web.Services.Discovery.DiscoveryDocumentReference),
            "http://localhost/Discovery/Service1_cs.asmx?disco",
            "Service1_cs.disco");

         // Add the DiscoveryClientResult to the collection.
         myDiscoveryClientResultCollection.Add(myDiscoveryClientResult);
// </Snippet1>
         Console.WriteLine("Displaying the items in the collection");
         for(int i=0;i<myDiscoveryClientResultCollection.Count;i++)
         {
            DiscoveryClientResult myClientResult = 
               myDiscoveryClientResultCollection[i];
            Console.WriteLine("DiscoveryClientResult Object "+(i+1));
            Console.WriteLine("Type of reference in the discovery document: "
               + myClientResult.ReferenceTypeName);
            Console.WriteLine("URL for reference: " + myClientResult.Url);
            Console.WriteLine("File for saving the reference: "
               + myClientResult.Filename);
         }
      }
      catch(Exception e)
      {
         Console.WriteLine("Error is "+e.Message);
      }
   }
}

