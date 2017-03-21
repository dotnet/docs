#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <WellKnownServiceTypeEntry_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

int main()
{
   // Create a 'HttpChannel' object and register it with the 
   // channel services.
   ChannelServices::RegisterChannel( gcnew HttpChannel( 8086 ) );

   // Record the 'HelloServer' type as 'Singleton' well-known type.
   WellKnownServiceTypeEntry^ myWellKnownServiceTypeEntry = gcnew WellKnownServiceTypeEntry( HelloServer::typeid,"SayHello",WellKnownObjectMode::Singleton );

   // Register the remote object as well-known type.
   RemotingConfiguration::RegisterWellKnownServiceType( myWellKnownServiceTypeEntry );

   // Retrieve object types registered on the service end 
   // as well-known types.
   array<WellKnownServiceTypeEntry^>^myWellKnownServiceTypeEntryCollection = RemotingConfiguration::GetRegisteredWellKnownServiceTypes();
   Console::WriteLine( "The 'WellKnownObjectMode' of the remote object : {0}", myWellKnownServiceTypeEntryCollection[ 0 ]->Mode );
   Console::WriteLine( "The 'WellKnownServiceTypeEntry' object: {0}", myWellKnownServiceTypeEntryCollection[ 0 ] );
   Console::WriteLine( "Started the Server, Hit <enter> to exit..." );
   Console::ReadLine();
}