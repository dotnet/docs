// System.Web.Services.Discovery.DiscoveryClientReferenceCollection

/*
   The following example demonstrates the class 
   'DiscoveryClientReferenceCollection'. A sample discovery document 
   is read and the 'Keys' and 'Values' properties are displayed. A 
   string containing the URL of a discovery document is passed as 
   an argument to 'Contains' method of the instance of the class. 
*/

// <Snippet1>
using System;
using System.Net;
using System.Collections;
using System.Security.Permissions;
using System.Web.Services.Discovery;

class MyDiscoveryClientReferenceCollection
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
      
      myDiscoveryClientProtocol.Credentials = 
          CredentialCache.DefaultCredentials;

      // 'dataservice.vsdisco' is a sample discovery document.
      string myStringUrl = "http://localhost/dataservice.vsdisco";
      
      // Call the Discover method to populate the References property.
      DiscoveryDocument myDiscoveryDocument = 
          myDiscoveryClientProtocol.Discover(myStringUrl);

      // Resolve all references found in the discovery document.
      myDiscoveryClientProtocol.ResolveAll();
      
      DiscoveryClientReferenceCollection myDiscoveryClientReferenceCollection = 
          myDiscoveryClientProtocol.References;
      
      // Retrieve the keys from the collection.
      ICollection myCollection = myDiscoveryClientReferenceCollection.Keys;
      object[] myObjectCollection = 
          new object[myDiscoveryClientReferenceCollection.Count];
      myCollection.CopyTo(myObjectCollection, 0);
      
      Console.WriteLine("The discovery documents, service descriptions, " +
            "and XML schema");
      Console.WriteLine(" definitions in the collection are: ");
      for (int i=0; i< myObjectCollection.Length; i++)
      {
         Console.WriteLine(myObjectCollection[i]);
      }
      Console.WriteLine("");

      // Retrieve the values from the collection.
      ICollection myCollection1 = myDiscoveryClientReferenceCollection.Values;
      object[] myObjectCollection1 = 
          new object[myDiscoveryClientReferenceCollection.Count];
      myCollection1.CopyTo(myObjectCollection1, 0);
      
      Console.WriteLine("The objects in the collection are: ");
      for (int i=0; i< myObjectCollection1.Length; i++)
      {
         Console.WriteLine(myObjectCollection1[i]);
      }

      Console.WriteLine("");

      string myStringUrl1 = "http://localhost/dataservice.vsdisco";
      if (myDiscoveryClientReferenceCollection.Contains(myStringUrl1))
      {
         Console.WriteLine("The document reference {0} is part of the collection.",
             myStringUrl1);
      }
   }
} 
// </Snippet1>
