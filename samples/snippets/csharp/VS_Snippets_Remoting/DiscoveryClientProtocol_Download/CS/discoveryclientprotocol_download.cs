/*
   System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientProtocol
   System.Web.Services.Discovery.DiscoveryClientProtocol.Download(ref String)
   
   The following example demonstrates the 'constructor' and the
   method 'Download' of the 'DiscoveryClientProtocol' class. The
   'Download' method downloads a discovery document into a stream.
   A sample discovery document is read and the method 'download'
   is applied on it.
*/
using System;
using System.Net;
using System.IO;
using System.Security.Permissions;
using System.Web.Services.Discovery;

class DiscoveryClientProtocol_Download
{
   static void Main()
   {
      Run();
   }

   [PermissionSetAttribute(SecurityAction.Demand, Name="FullTrust")]
   static void Run()
   {
// <Snippet1>
// <Snippet2>
      // Call the constructor of the DiscoveryClientProtocol class.
      DiscoveryClientProtocol myDiscoveryClientProtocol =
                  new DiscoveryClientProtocol();
      myDiscoveryClientProtocol.Credentials =  CredentialCache.DefaultCredentials;
     // 'dataservice.disco' is a sample discovery document.
     string myStringUrl = "http://localhost:80/dataservice.disco";

      Stream myStream = myDiscoveryClientProtocol.Download(ref myStringUrl);

      Console.WriteLine("Size of the discovery document downloaded");
      Console.WriteLine("is : {0} bytes", myStream.Length.ToString());
      myStream.Close();
// </Snippet1>
// </Snippet2>
   }
} 


