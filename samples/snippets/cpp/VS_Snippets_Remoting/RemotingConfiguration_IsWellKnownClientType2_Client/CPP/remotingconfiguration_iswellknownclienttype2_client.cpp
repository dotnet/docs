

// System.Runtime.Remoting.RemotingConfiguration.IsWellKnownClientType(String,String)
/*
The following example demonstrates the 'IsWellKnownClientType(String,String)' method
of 'RemotingConfiguration' class. It registers a 'TcpChannel' object with the channel
services. Then registers the 'MyServerImpl' object as well-known type at the client end.
and displays it's properties to the console.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_IsWellKnownClientType2_Shared.dll>

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel, false );

   // Register the 'MyServerImpl' object as well known type 
   // at client end.
   RemotingConfiguration::RegisterWellKnownClientType( MyServerImpl::typeid, "tcp://localhost:8085/SayHello" );

   // <Snippet1>
   MyServerImpl ^ myObject = gcnew MyServerImpl;

   // Get the assembly for the 'MyServerImpl' object.
   Assembly^ myAssembly = Assembly::GetAssembly( MyServerImpl::typeid );
   AssemblyName^ myName = myAssembly->GetName();

   // Check whether the specified object type is registered as
   // well-known client type.
   WellKnownClientTypeEntry^ myWellKnownClientType = RemotingConfiguration::IsWellKnownClientType( MyServerImpl::typeid->FullName, myName->Name );
   Console::WriteLine( "The Object type :{0}", myWellKnownClientType->ObjectType );
   Console::WriteLine( "The Object Uri :{0}", myWellKnownClientType->ObjectUrl );
   // </Snippet1>
   Console::WriteLine( myObject->MyMethod( "Remote method is called." ) );
}
