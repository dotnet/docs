/*
   System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Keys
   System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Values
   System.Web.Services.Discovery.DiscoveryClientDocumentCollection.Contains(String)
   
   The following example demonstrates the 'Keys', 'Values' properties
   and the 'Contains' method. The 'Keys' property returns the names
   the discoverydocuments in the 'DiscoveryClientDocumentCollection' and 
   the 'Values' property returns the type of objects in the 
   'DiscoveryClientDocumentCollection'. A sample discovery document is read
   and the properties 'Keys' and 'Values' and the method 'Contains' are 
   displayed.
*/
using System;
using System.Net;
using System.IO;
using System.Collections;
using System.Security.Permissions;
using System.Web.Services.Discovery;

class DiscoveryClientDocumentCollectionSample_Keys
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
      
      DiscoveryClientDocumentCollection myDiscoveryClientDocumentCollection = 
                        myDiscoveryClientProtocol.Documents;
      
      // 'Keys' in the collection are retrieved.
// <Snippet1>
      ICollection myCollection = myDiscoveryClientDocumentCollection.Keys;
      object[] myObjectCollection = 
                     new object[myDiscoveryClientDocumentCollection.Count];
      myCollection.CopyTo(myObjectCollection, 0);
      Console.WriteLine("The discovery documents in the collection are :");
      for (int iIndex=0; iIndex < myObjectCollection.Length; iIndex++)
      {
         Console.WriteLine(myObjectCollection[iIndex]);
      }
// </Snippet1>
      Console.WriteLine("");
// <Snippet2>
      // 'Values' in the collection are retrieved.
      ICollection myCollection1 = myDiscoveryClientDocumentCollection.Values;
      object[] myObjectCollection1 = 
                     new object[myDiscoveryClientDocumentCollection.Count];
      myCollection1.CopyTo(myObjectCollection1, 0);
      Console.WriteLine("The objects in the collection are :");
      for (int iIndex=0; iIndex < myObjectCollection1.Length; iIndex++)
         Console.WriteLine(myObjectCollection1[iIndex]);
// </Snippet2>
      Console.WriteLine("");
// <Snippet3>
      bool myContains = myDiscoveryClientDocumentCollection.Contains(myStringUrl);
      if (myContains)
         Console.WriteLine("The discovery document {0} is present in the" 
                           + " Collection",myStringUrl);
// </Snippet3>
   }
} 


