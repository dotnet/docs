

// <Snippet1>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using <service.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Principal;
int main()
{
   GenericIdentity^ ident = gcnew GenericIdentity( "Bob" );
   array<String^>^id = gcnew array<String^>(1);
   id[ 0 ] = "Level1";
   GenericPrincipal^ prpal = gcnew GenericPrincipal( ident,id );
   LogicalCallContextData ^ data = gcnew LogicalCallContextData( prpal );

   //Enter data into the CallContext
   CallContext::SetData( "test data", data );
   Console::WriteLine( data->numOfAccesses );
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   RemotingConfiguration::RegisterActivatedClientType( HelloServiceClass::typeid, "tcp://localhost:8082" );
   HelloServiceClass ^ service = gcnew HelloServiceClass;
   if ( service == nullptr )
   {
      Console::WriteLine( "Could not locate server." );
      return 0;
   }

   // call remote method
   Console::WriteLine();
   Console::WriteLine( "Calling remote Object*" );
   Console::WriteLine( service->HelloMethod( "Caveman" ) );
   Console::WriteLine( service->HelloMethod( "Spaceman" ) );
   Console::WriteLine( service->HelloMethod( "Bob" ) );
   Console::WriteLine( "Finished remote Object* call" );
   Console::WriteLine();

   //Extract the returned data from the call context
   LogicalCallContextData ^ returnedData = static_cast<LogicalCallContextData ^>(CallContext::GetData( "test data" ));
   Console::WriteLine( data->numOfAccesses );
   Console::WriteLine( returnedData->numOfAccesses );
   return 0;
}
// </Snippet1>
