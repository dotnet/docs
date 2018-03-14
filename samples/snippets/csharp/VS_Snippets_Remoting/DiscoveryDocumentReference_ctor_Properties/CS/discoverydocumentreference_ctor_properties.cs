// System.Web.Services.Discovery.DiscoveryDocumentReference.DiscoveryDocumentReference(string)
// System.Web.Services.Discovery.DiscoveryDocumentReference.Ref
// System.Web.Services.Discovery.DiscoveryDocumentReference.Url
// System.Web.Services.Discovery.DiscoveryDocumentReference.DefaultFileName

/*
   This program demonstrates the 'DiscoveryDocumentReference(string)' Constructor, 'Ref',
   'Url', and 'DefaultFileName' properties of the 'DiscoveryDocumentReference' class.
   It creates an instance of 'DiscoveryDocumentReference' and displays the 'Ref', 'Url' and
   'DefaultFilename' properties.
*/

using System;
using System.Xml;
using System.Web.Services.Discovery;

public class DiscoveryDocumentReference_ctor_Properties
{
    public static void Main()
    {
        try
        {
// <Snippet1>
            DiscoveryDocumentReference myDiscoveryDocumentReference = 
                new DiscoveryDocumentReference(
                "http://localhost/Sample_cs.disco");
// </Snippet1>

            Console.WriteLine("The reference to the discovery document is: ");

// <Snippet2>
            // Display the discovery document reference.
            Console.WriteLine(myDiscoveryDocumentReference.Ref.ToString());
// </Snippet2>
            Console.WriteLine();
            Console.WriteLine(
                "The URL of the referenced discovery document is: ");

// <Snippet3>
            // Display the URL of the referenced discovery document.
            Console.WriteLine(myDiscoveryDocumentReference.Url.ToString());
// </Snippet3>
            Console.WriteLine();
            Console.WriteLine("The name of the default disco file is: ");

// <Snippet4>
            // Display the name of the default file used for reference.
            Console.WriteLine(
                myDiscoveryDocumentReference.DefaultFilename.ToString());
// </Snippet4>
         }
        catch(Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
        }
    }
}
