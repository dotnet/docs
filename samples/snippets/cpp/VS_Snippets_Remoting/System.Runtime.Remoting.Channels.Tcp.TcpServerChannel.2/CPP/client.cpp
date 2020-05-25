

#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "common.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   // Create the channel.
   TcpClientChannel^ channel = gcnew TcpClientChannel;

   // Register the channel.
   ChannelServices::RegisterChannel( channel );

   // Register as client for remote object.
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry( Remotable::typeid,"tcp://localhost:9090/Remotable.rem" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );

   // Create an instance of the remote object.
   Remotable^ service = gcnew Remotable;

   // Invoke a method on the remote object.
   Console::WriteLine( "The client is invoking the remote object." );
   Console::WriteLine( "The remote object has been called {0} times.", service->GetCount() );
}
