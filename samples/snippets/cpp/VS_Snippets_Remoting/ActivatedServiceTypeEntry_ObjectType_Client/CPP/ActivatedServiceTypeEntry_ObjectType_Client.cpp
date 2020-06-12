#using <System.Runtime.Remoting.dll>
#using <ActivatedServiceTypeEntry_ObjectType_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

void main()
{
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   ActivatedClientTypeEntry^ activatedClientTypeEntry = gcnew ActivatedClientTypeEntry( HelloServer::typeid,"tcp://localhost:8082" );

   // Register 'HelloServer' Type on the client end so that it can be
   // activated on the server.
   RemotingConfiguration::RegisterActivatedClientType( activatedClientTypeEntry );

   // Obtain a proxy object for the remote object.
   HelloServer^ helloServer = gcnew HelloServer( "ParameterString" );
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
