// System.Web.Services.Discovery.DiscoveryDocumentReference.ReadDocument(stream)

/*
   This program demonstrates the 'ReadDocument(stream)' of 'DiscoveryDocumentReference'
   class. Read the contents of the discovery document from the stream and returns 
   discovery document reference. The references of the 'DiscoveryDocumentReference'
   are printed.
*/

using System;
using System.Web.Services.Discovery;
using System.IO;
using System.Collections;
using System.Security.Permissions;

class DiscoveryDocumentReference_ReadDocument 
{

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   static void Run()
{
      try
      {
// <Snippet1>
         string myUrl = "http://localhost/Sample_cs.vsdisco";
         DiscoveryClientProtocol myProtocol = new DiscoveryClientProtocol();
         DiscoveryDocumentReference myReference = new DiscoveryDocumentReference(myUrl);
         Stream myFileStream = myProtocol.Download(ref myUrl);
         DiscoveryDocument myDiscoveryDocument = 
                           (DiscoveryDocument)myReference.ReadDocument(myFileStream);
// </Snippet1>
         IEnumerator myEnumerator = myDiscoveryDocument.References.GetEnumerator();
         Console.WriteLine("\nThe references to the discovery document are : \n");
         while(myEnumerator.MoveNext())
         {
            DiscoveryDocumentReference myNewReference = 
                                 (DiscoveryDocumentReference)myEnumerator.Current;
            // Print the discovery document references on the console.
            Console.WriteLine(myNewReference.Url);
         }
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception:{0}", e.Message);
      }
}
   static void Main()
   {
      Run();
   }
}