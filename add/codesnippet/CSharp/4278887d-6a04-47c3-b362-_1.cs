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
      }
      catch(Exception e)
      {
          Console.WriteLine(e.Message);
      }
   }
}