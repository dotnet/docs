

// <snippet20>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <Remotable.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   
   // <snippet21>
   // Set up a client channel.
   TcpClientChannel^ clientChannel = gcnew TcpClientChannel;
   ChannelServices::RegisterChannel( clientChannel );
   
   // </snippet21>
   // <snippet22>
   // Show the name and priority of the channel.
   Console::WriteLine( "Channel Name: {0}", clientChannel->ChannelName );
   Console::WriteLine( "Channel Priority: {0}", clientChannel->ChannelPriority );
   
   // </snippet22>
   // Obtain a proxy for a remote object.
   RemotingConfiguration::RegisterWellKnownClientType( Remotable::typeid, "tcp://localhost:9090/Remotable.rem" );
   
   // Call a method on the object.
   Remotable ^ remoteObject = gcnew Remotable;
   Console::WriteLine( remoteObject->GetCount() );
}

// </snippet20>
