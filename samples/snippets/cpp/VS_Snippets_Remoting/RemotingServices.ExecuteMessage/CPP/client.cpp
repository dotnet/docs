

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "serviceclass.dll"

using namespace System;
using namespace System::Diagnostics;
using namespace System::Reflection;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry( SampleService::typeid,"tcp://localhost:9000/SampleServiceUri" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );
   SampleService^ service = gcnew SampleService;
   Console::WriteLine( "Connected to SampleService" );
   service->UpdateServer( 3, 3.14, "Pi" );
   return 0;
}
