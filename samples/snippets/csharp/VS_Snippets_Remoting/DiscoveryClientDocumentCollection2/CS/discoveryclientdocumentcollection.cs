/*
   System.Web.Services.Discovery.DiscoveryClientDocumentCollection

   The following example demonstrates the class 'DiscoveryClientDocumentCollection'.
   A sample discovery document is read and the 'Keys' and 'Values' properties 
   are displayed.
*/

// <Snippet1>
using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Security.Permissions;
using System.Web.Services.Discovery;

class DiscoveryClientDocumentCollectionSample
{
   static void Main()
   {
      Run();
   }

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   static void Run()
   {
      DiscoveryClientProtocol myDiscoveryClientProtocol =
         new DiscoveryClientProtocol();
      
      myDiscoveryClientProtocol.Credentials = CredentialCache.DefaultCredentials;

      // 'dataservice.disco' is a sample discovery document.
      string myStringUrl = "http://localhost/dataservice.disco";
      
      // 'Discover' method is called to populate the 'Documents' property.
      DiscoveryDocument myDiscoveryDocument = 
         myDiscoveryClientProtocol.Discover(myStringUrl);

      // An instance of the 'DiscoveryClientDocumentCollection' class is created.
      DiscoveryClientDocumentCollection myDiscoveryClientDocumentCollection = 
         myDiscoveryClientProtocol.Documents;
      
      // 'Keys' in the collection are retrieved.
      ICollection myCollection = myDiscoveryClientDocumentCollection.Keys;
      object[] myObjectCollection = 
         new object[myDiscoveryClientDocumentCollection.Count];
      myCollection.CopyTo(myObjectCollection, 0);
      
      Console.WriteLine("The discovery documents in the collection are :");
      for (int iIndex=0; iIndex < myObjectCollection.Length; iIndex++)
      {
         Console.WriteLine(myObjectCollection[iIndex]);
      }
      
      Console.WriteLine("");

      // 'Values' in the collection are retrieved.
      ICollection myCollection1 = myDiscoveryClientDocumentCollection.Values;
      object[] myObjectCollection1 = 
         new object[myDiscoveryClientDocumentCollection.Count];
      myCollection1.CopyTo(myObjectCollection1, 0);
      
      Console.WriteLine("The objects in the collection are :");
      for (int iIndex=0; iIndex < myObjectCollection1.Length; iIndex++)
      {
         Console.WriteLine(myObjectCollection1[iIndex]);
      }
   }
} 
// </Snippet1>
