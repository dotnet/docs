// System.Web.Services.DiscoveryClientResult

/*
The following example demonstrates 'DiscoveryClientResult' class.
A 'DiscoveryClientResultCollection' object is obtained by reading a
'.discomap' file which contains the 'DiscoveryClientResult' objects,
representing the details of discovery references. The contents of this
collection are displayed..
*/

// <Snippet1>
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

            // Get the collection holding DiscoveryClientResult objects.
            DiscoveryClientResultCollection myDiscoveryClientResultCollection = 
                myDiscoveryClientProtocol.ReadAll("results.discomap");
            Console.WriteLine("The number of DiscoveryClientResult objects: "
                + myDiscoveryClientResultCollection.Count);
            Console.WriteLine("Displaying the items in the collection:");

            // Iterate through the collection and display the properties
            // of each DiscoveryClientResult in it.
            foreach(DiscoveryClientResult myDiscoveryClientResult in 
                myDiscoveryClientResultCollection)
            {
                Console.WriteLine(
                    "Type of reference in the discovery document: "
                    + myDiscoveryClientResult.ReferenceTypeName);
                Console.WriteLine("Url for the reference: " 
                    + myDiscoveryClientResult.Url);
                Console.WriteLine("File for saving the reference: "
                    + myDiscoveryClientResult.Filename);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Error is " + e.Message);
        }
    }
}
// </Snippet1>
