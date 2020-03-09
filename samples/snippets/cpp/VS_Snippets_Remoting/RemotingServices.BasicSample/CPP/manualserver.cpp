

#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace SampleNamespace;

// Note: this snippet is based on v-ralphs' Dynamic Remoting sample.
int main()
{
   // <Snippet2>
   TcpChannel^ channel = gcnew TcpChannel( 9000 );
   ChannelServices::RegisterChannel( channel );
   SampleWellKnown ^ objectWellKnown = gcnew SampleWellKnown;

   // After the channel is registered, the Object* needs to be registered
   // with the remoting infrastructure.  So, Marshal is called.
   ObjRef^ objrefWellKnown = RemotingServices::Marshal( objectWellKnown, "objectWellKnownUri" );
   Console::WriteLine( "An instance of SampleWellKnown type is published at {0}.", objrefWellKnown->URI );
   Console::WriteLine( "Press enter to unregister SampleWellKnown, so that it is no longer available on this channel." );
   Console::ReadLine();
   RemotingServices::Disconnect( objectWellKnown );
   Console::WriteLine( "Press enter to end the server process." );
   Console::ReadLine();
   // </Snippet2>

   return 0;
}
