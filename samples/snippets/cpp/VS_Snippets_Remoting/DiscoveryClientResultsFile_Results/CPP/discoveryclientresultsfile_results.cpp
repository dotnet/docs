

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
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::Net;
using namespace System::Xml;
using namespace System::Xml::Serialization;

int main()
{
   String^ outputDirectory = "c:\\InetPub\\wwwroot";
   DiscoveryClientProtocol^ myClient = gcnew DiscoveryClientProtocol;

   //  Use default credentials to access the URL being discovered.
   myClient->Credentials = CredentialCache::DefaultCredentials;
   try
   {
      DiscoveryDocument^ myDocument;

      // Discover the supplied URL to determine if it is a discovery document.
      myDocument = myClient->Discover( "http://localhost/MathService_cs.vsdisco" );
      myClient->ResolveAll();
      DiscoveryClientResultCollection^ myCollection = myClient->WriteAll( outputDirectory, "MyDiscoMap.discomap" );

      // <Snippet2>
      // <Snippet3>
      // Get the DiscoveryClientProtocol.DiscoveryClientResultsFile.
      DiscoveryClientProtocol::DiscoveryClientResultsFile ^ myResultFile = gcnew DiscoveryClientProtocol::DiscoveryClientResultsFile;
      XmlSerializer^ mySerializer = gcnew XmlSerializer( myResultFile->GetType() );
      XmlReader^ reader = gcnew XmlTextReader( "http://localhost/MyDiscoMap.discomap" );
      myResultFile = dynamic_cast<DiscoveryClientProtocol::DiscoveryClientResultsFile^>(mySerializer->Deserialize( reader ));

      // Get a collection of DiscoveryClientResult objects.
      DiscoveryClientResultCollection^ myResultcollection = myResultFile->Results;
      Console::WriteLine( "Referred file(s): " );
      System::Collections::IEnumerator^ myEnum = myResultcollection->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DiscoveryClientResult^ myResult = safe_cast<DiscoveryClientResult^>(myEnum->Current);
         Console::WriteLine( myResult->Filename );
      }
      // </Snippet3>
      // </Snippet2>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->Message );
   }
}
// </Snippet1>
