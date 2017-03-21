#using <System.Runtime.Remoting.dll>
#using <ActivatedClientTypeEntry_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
static void main()
{
   // Register TCP Channel.
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   
   // Create activated client type entry.
   ActivatedClientTypeEntry^ activatedClientTypeEntry = gcnew ActivatedClientTypeEntry( HelloServer::typeid, "tcp://localhost:8082" );
   
   // Register type on client to activate it on the server.
   RemotingConfiguration::RegisterActivatedClientType( activatedClientTypeEntry );
   
   // Activate a client activated object type.
   HelloServer^ helloServer = gcnew HelloServer( "ParameterString" );
   
   // Print the object type.
   Console::WriteLine( "Object type of client activated object: {0}", activatedClientTypeEntry->ObjectType->ToString() );
   
   // Print the application URL.
   Console::WriteLine( "Application url where the type is activated: {0}", activatedClientTypeEntry->ApplicationUrl->ToString() );
   
   // Print the string representation of the type entry.
   Console::WriteLine( "Type and assembly name and application URL of the remote object: {0}", activatedClientTypeEntry->ToString() );
   
   // Print a blank line.
   Console::WriteLine();
   
   // Check that server was located.
   if (  !helloServer )
   {
      Console::WriteLine( "Could not locate server" );
   }
   else
   {
      Console::WriteLine( "Calling remote object" );
      Console::WriteLine( helloServer->HelloMethod( "Bill" ) );
   }
}