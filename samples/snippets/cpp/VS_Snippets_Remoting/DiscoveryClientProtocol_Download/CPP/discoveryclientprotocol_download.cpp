/*
System::Web::Services::Discovery.DiscoveryClientProtocol::DiscoveryClientProtocol
System::Web::Services::Discovery.DiscoveryClientProtocol::Download(String)*

The following example demonstrates the 'constructor' and the
method 'Download' of the 'DiscoveryClientProtocol' class. The
'Download' method downloads a discovery document into a stream.
A sample discovery document is read and the method 'download'
is applied on it.
*/

#using <System.dll>
#using <System.Web.Services.dll>

using namespace System;
using namespace System::Net;
using namespace System::IO;
using namespace System::Web::Services::Discovery;

int main()
{
// <Snippet1>
// <Snippet2>
   // Call the constructor of the DiscoveryClientProtocol class.
   DiscoveryClientProtocol^ myDiscoveryClientProtocol =
      gcnew DiscoveryClientProtocol;
   myDiscoveryClientProtocol->Credentials = CredentialCache::DefaultCredentials;
   // 'dataservice.disco' is a sample discovery document.
   String^ myStringUrl = "http://localhost:80/dataservice.disco";

   Stream^ myStream = myDiscoveryClientProtocol->Download( myStringUrl );

   Console::WriteLine( "Size of the discovery document downloaded" );
   Console::WriteLine( "is : {0} bytes", myStream->Length );
   myStream->Close();
// </Snippet2>
// </Snippet1>
}
