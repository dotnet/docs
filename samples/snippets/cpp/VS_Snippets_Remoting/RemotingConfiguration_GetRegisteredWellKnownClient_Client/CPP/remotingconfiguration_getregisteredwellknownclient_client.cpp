

// System.Runtime.Remoting.RemotingConfiguration.GetRegisteredWellKnownClientTypes
/*
The following example demonstrates the 'GetRegisteredWellKnownClientTypes' method
of 'RemotingConfiguration' class. 
It registers a 'TcpChannel' object with the channel services. Then registers the 
'MyServerImpl' object as well-known type at the client end. By using the 
'GetRegisteredWellKnownClientTypes' method it gets well-known types registered
at the client side and displays it's properties to the console.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <RemotingConfiguration_GetRegisteredWellKnownClient_Shared.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   
   // Register the specified object as well-known type at client end.
   RemotingConfiguration::RegisterWellKnownClientType( MyServerImpl::typeid, "tcp://localhost:8085/SayHello" );
   MyServerImpl ^ myObject = gcnew MyServerImpl;
   Console::WriteLine( myObject->MyMethod( "ClientString" ) );
   
   // <Snippet1>
   // Get the well-known types registered at the client.
   array<WellKnownClientTypeEntry^>^myEntries = RemotingConfiguration::GetRegisteredWellKnownClientTypes();
   Console::WriteLine( "The number of WellKnownClientTypeEntries are:{0}", myEntries->Length );
   Console::WriteLine( "The Object type is:{0}", myEntries[ 0 ]->ObjectType );
   Console::WriteLine( "The Object Url is:{0}", myEntries[ 0 ]->ObjectUrl );
   // </Snippet1>
}
