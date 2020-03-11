// System.Web.Services.Discovery.ContractReference.Contract
/* 
The following example demonstrates the 'Contract' property of the 'ContractReference'
class.
It creates an instance of 'DiscoveryDocument' class by reading from a disco file 
and gets the first reference to a service description in a 'ContractReference' instance.
Using the 'Contract' property of the 'ContractReference' instance it creates a wsdl 
file which works as a service description file.
*/
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Protocols;
using namespace System::Net;
using namespace System::IO;
using namespace System::Web::Services::Discovery;
using namespace System::Web::Services::Description;

// <Snippet1>
int main()
{
   try
   {
      // Create the file stream.
      FileStream^ discoStream = gcnew FileStream( "Service1_CS.disco",FileMode::Open );
      
      // Create the discovery document.
      DiscoveryDocument^ myDiscoveryDocument = DiscoveryDocument::Read( discoStream );
      
      // Get the first ContractReference in the collection.
      ContractReference^ myContractReference = dynamic_cast<ContractReference^>(myDiscoveryDocument->References[ 0 ]);
      
      // Set the client protocol.
      myContractReference->ClientProtocol = gcnew DiscoveryClientProtocol;
      myContractReference->ClientProtocol->Credentials = CredentialCache::DefaultCredentials;
      
      // Get the service description.
      ServiceDescription^ myContract = myContractReference->Contract;
      
      // Create the service description file.
      myContract->Write( "MyService1.wsdl" );
      Console::WriteLine( "The WSDL file created is MyService1.wsdl" );
      discoStream->Close();
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "Exception: {0}", ex->Message );
   }
}
// </Snippet1>
