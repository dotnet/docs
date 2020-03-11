// System.Web.Services.Discovery.ContractReference.DefaultFileName
// System.Web.Services.Discovery.ContractReference.Url
/*
The following example demonstrates the 'DefaultFilename' and 'Url' properties of 
'ContractReference' class. It gets the 'DiscoveryDocument' object using the 
'Discover' method of 'DiscoveryClientProtocol' class. It gets the 'ContractReference'
object by using the 'References' property of 'DiscoveryDocument' object.Then it displays the
'DefaultFileName' and 'Url' properties of 'ContractReference'.
*/
#using <System.Xml.dll>
#using <System.Web.Services.dll>
#using <System.dll>

using namespace System;
using namespace System::Web::Services::Discovery;
using namespace System::Xml::Schema;
using namespace System::Collections;

int main()
{
   // <Snippet1>
   // <Snippet2>
   DiscoveryClientProtocol^ myProtocol = gcnew DiscoveryClientProtocol;
   
   // Get the DiscoveryDocument.
   DiscoveryDocument^ myDiscoveryDocument = myProtocol->Discover( "http://localhost/ContractReference/test_cs.disco" );
   ArrayList^ myArrayList = dynamic_cast<ArrayList^>(myDiscoveryDocument->References);
   
   // Get the ContractReference.
   ContractReference^ myContractRefrence = dynamic_cast<ContractReference^>(myArrayList[ 0 ]);
   
   // Get the DefaultFileName associated with the .disco file.
   String^ myFileName = myContractRefrence->DefaultFilename;
   
   // Get the URL associated with the .disco file.
   String^ myUrl = myContractRefrence->Url;
   Console::WriteLine( "The DefaulFilename is: {0}", myUrl );
   Console::WriteLine( "The URL is: {0}", myUrl );
   // </Snippet2>
   // </Snippet1>
}
