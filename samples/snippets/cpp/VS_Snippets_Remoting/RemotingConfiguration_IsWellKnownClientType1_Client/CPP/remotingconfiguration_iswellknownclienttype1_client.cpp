

// System.Runtime.Remoting.RemotingConfiguration.IsWellKnownClientType(Type)
/*
The following example demonstrates the 'IsWellKnownClientType(Type)' method
of 'RemotingConfiguration' class. It registers a 'TcpChannel' object with the channel
services. Then registers the 'MyServerImpl' object as well-known type. By using the above 
method it gets the well-known type registered at the client side and displays it's 
properties to the console.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_IsWellKnownClientType1_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel, false );

   // Register the 'MyServerImpl' object as well known type 
   // at client end.
   RemotingConfiguration::RegisterWellKnownClientType( MyServerImpl::typeid, "tcp://localhost:8085/SayHello" );
   MyServerImpl ^ myObject = gcnew MyServerImpl;
   Console::WriteLine( myObject->MyMethod( "ClientString" ) );

   // <Snippet1>
   // Check whether the specified object type is registered as 
   // well known client type or not.
   WellKnownClientTypeEntry^ myWellKnownClientType = RemotingConfiguration::IsWellKnownClientType( MyServerImpl::typeid );
   Console::WriteLine( "The Object type is {0}", myWellKnownClientType->ObjectType );
   Console::WriteLine( "The Object Url is {0}", myWellKnownClientType->ObjectUrl );
   // </Snippet1>
}
