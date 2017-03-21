#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <WellKnownClientTypeEntry_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

int main()
{
   // Create a 'HttpChannel' object and  register with channel services.
   ChannelServices::RegisterChannel( gcnew HttpChannel );
   Console::WriteLine( " Start calling from Client One......." );
   WellKnownClientTypeEntry^ myWellKnownClientTypeEntry = gcnew WellKnownClientTypeEntry( HelloServer::typeid,"http://localhost:8086/SayHello" );
   myWellKnownClientTypeEntry->ApplicationUrl = "http://localhost:8086/SayHello";
   RemotingConfiguration::RegisterWellKnownClientType( myWellKnownClientTypeEntry );

   // Get the proxy object for the remote object.
   HelloServer^ myHelloServerObject = gcnew HelloServer;

   // Retrieve an array of object types registered on the 
   // client end as well-known types.
   array<WellKnownClientTypeEntry^>^myWellKnownClientTypeEntryCollection = RemotingConfiguration::GetRegisteredWellKnownClientTypes();
   Console::WriteLine( "The Application Url to activate the Remote Object :{0}", myWellKnownClientTypeEntryCollection[ 0 ]->ApplicationUrl );
   Console::WriteLine( "The 'WellKnownClientTypeEntry' object :{0}", myWellKnownClientTypeEntryCollection[ 0 ] );

   // Make remote method calls.
   for ( int i = 0; i < 5; i++ )
      Console::WriteLine( myHelloServerObject->HelloMethod( " Client One" ) );
}