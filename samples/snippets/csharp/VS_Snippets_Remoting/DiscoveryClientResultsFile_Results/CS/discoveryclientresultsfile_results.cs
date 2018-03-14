// System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientResultsFile
// System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientResultsFile.ctor
// System.Web.Services.Discovery.DiscoveryClientProtocol.DiscoveryClientResultsFile.Results
/*
The following example demonstrates the usage of 'DiscoveryClientProtocol.
DiscoveryClientResultsFile' class, constructor 'DiscoveryClientProtocol.
DiscoveryClientResultsFile()' and the property 'Results' of the class.
The input to the program is a VSDisco file 'MathService.vsdisco', which
holds reference to 'MathService' web service. The 'Results' property returns
all valid references of the discovery document 'MathService.vsdisco'.
*/
// <Snippet1>
using System;
using System.Web.Services.Discovery;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

class myDiscoveryClient_Results
{
   static void Main()
   {
      string outputDirectory = "c:\\InetPub\\wwwroot";
      DiscoveryClientProtocol myClient = new DiscoveryClientProtocol();
      
      //  Use default credentials to access the URL being discovered.
      myClient.Credentials = CredentialCache.DefaultCredentials;
      try 
      {
         DiscoveryDocument myDocument;

         // Discover the supplied URL to determine if it is a discovery document.
         myDocument = myClient.Discover("http://localhost/MathService_cs.vsdisco");
         myClient.ResolveAll();
         DiscoveryClientResultCollection myCollection = 
             myClient.WriteAll(outputDirectory, "MyDiscoMap.discomap");
// <Snippet2>
// <Snippet3>
         // Get the DiscoveryClientProtocol.DiscoveryClientResultsFile.
         DiscoveryClientProtocol.DiscoveryClientResultsFile myResultFile =
             new DiscoveryClientProtocol.DiscoveryClientResultsFile();
         XmlSerializer mySerializer = new XmlSerializer(myResultFile.GetType()); 
         XmlReader reader = new XmlTextReader("http://localhost/MyDiscoMap.discomap");
         myResultFile = (DiscoveryClientProtocol.DiscoveryClientResultsFile)
             mySerializer.Deserialize(reader);

         // Get a collection of DiscoveryClientResult objects.
         DiscoveryClientResultCollection myResultcollection = myResultFile.Results;

         Console.WriteLine("Referred file(s): ");
         foreach(DiscoveryClientResult myResult in myResultcollection)
         {
             Console.WriteLine(myResult.Filename);
         }
// </Snippet3>
// </Snippet2>
      }
      catch(Exception e)
      {
          Console.WriteLine(e.Message);
      }
   }
}
// </Snippet1>
