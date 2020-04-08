

// <Snippet5>
#using <system.dll>
#using <system.runtime.remoting.dll>
#using "service.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels::Tcp;
using namespace System::Runtime::Remoting::Channels;
int main()
{
   // </Snippet5>
   // <Snippet6>
   ChannelServices::RegisterChannel( gcnew TcpChannel );
   RemotingConfiguration::RegisterWellKnownClientType( HelloService::typeid,
                                                       "tcp://localhost:8082/HelloServiceApplication/MyUri" );
   HelloService ^ service = gcnew HelloService;
   // </Snippet6>
   // <Snippet7>
   if ( service == nullptr )
   {
      Console::WriteLine( "Could not locate server." );
      return  -1;
   }

   // Calls the remote method.
   Console::WriteLine();
   Console::WriteLine( "Calling remote Object*" );
   Console::WriteLine( service->HelloMethod( "Caveman" ) );
   Console::WriteLine( service->HelloMethod( "Spaceman" ) );
   Console::WriteLine( service->HelloMethod( "Client Man" ) );
   Console::WriteLine( "Finished remote Object* call" );
   Console::WriteLine();
   return 0;
}
// </Snippet7>
