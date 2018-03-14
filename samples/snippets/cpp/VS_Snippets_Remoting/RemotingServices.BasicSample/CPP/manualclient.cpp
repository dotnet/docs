

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Net::Sockets;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace SampleNamespace;

// Note: this snippet is based on v-ralphs' Dynamic Remoting sample.
int main()
{
   // System::Runtime::Remoting::RemotingServices.Disconnect() -- ManualServer::cs has a snippet for Disconnect, too.

   // <Snippet3>
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry( SampleWellKnown::typeid,"tcp://localhost:9000/objectWellKnownUri" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );
   SampleWellKnown^ objectWellKnown = gcnew SampleWellKnown;
   try
   {
      objectWellKnown->Add( 2, 3 );
      Console::WriteLine( "The add method on SampleWellKnown was successfully called." );
   }
   catch ( SocketException^ ) 
   {
      Console::WriteLine( "The server is not available.  Is it still running?" );
   }
   catch ( RemotingException^ ) 
   {
      Console::WriteLine( "SampleWellKnown is currently not available.  The server probably called Disconnect()." );
   }
   // </Snippet3>
   return 0;
}
