

// <snippet30>
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
   // <snippet31>
   // Specify client channel properties.
   IDictionary^ dict = gcnew Hashtable;
   dict[ "port" ] = 9090;
   dict[ "impersonationLevel" ] = "Identify";
   dict[ "authenticationPolicy" ] = "AuthPolicy, Policy";

   // Set up a client channel.
   TcpClientChannel^ clientChannel = gcnew TcpClientChannel( dict, nullptr );
   ChannelServices::RegisterChannel( clientChannel, false );
   // </snippet31>

   // Obtain a proxy for a remote object.
   RemotingConfiguration::RegisterWellKnownClientType( Remotable::typeid, "tcp://localhost:9090/Remotable.rem" );

   // Call a method on the object.
   Remotable ^ remoteObject = gcnew Remotable;
   Console::WriteLine( remoteObject->GetMessage() );
}
// </snippet30>
