

// <snippet20>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <Remotable.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   // <snippet21>
   // Specify server channel properties.
   IDictionary^ dict = gcnew Hashtable;
   dict[ "port" ] = 9090;
   dict[ "authenticationMode" ] = "IdentifyCallers";

   // Set up a server channel.
   TcpServerChannel^ serverChannel = gcnew TcpServerChannel( dict, nullptr );
   ChannelServices::RegisterChannel( serverChannel, false );

   // </snippet21>
   // Set up a remote object.
   RemotingConfiguration::RegisterWellKnownServiceType( Remotable::typeid, "Remotable.rem", WellKnownObjectMode::Singleton );

   // Wait for method calls.
   Console::WriteLine( "Listening..." );
   Console::ReadLine();
}
// </snippet20>
