//<snippet40>
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

void main()
{
   // Create the server channel.
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel( 9090 );
   
   // Register the server channel.
   ChannelServices::RegisterChannel( serverChannel );
   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType( RemoteObject::typeid, L"RemoteObject.rem", WellKnownObjectMode::Singleton );
   
   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}
//</snippet40>
