

/// Snippets needed: 
///    21    Ctor(string, int)
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "common.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   //<snippet21>
   // Create the server channel.
   TcpServerChannel^ channel = gcnew TcpServerChannel( "Server Channel",9090 );

   //</snippet21>
   // Register the server channel.
   ChannelServices::RegisterChannel( channel );

   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType( Remotable::typeid, "Remotable.rem", WellKnownObjectMode::Singleton );

   // Display the channel's URI.
   Console::WriteLine( "The channel URI is {0}.", channel->GetChannelUri() );

   // Parse the channel's URI.
   array<String^>^urls = channel->GetUrlsForUri( "Remotable.rem" );
   if ( urls->Length > 0 )
   {
      String^ objectUrl = urls[ 0 ];
      String^ objectUri;
      String^ channelUri = channel->Parse( objectUrl, objectUri );
      Console::WriteLine( "The object URI is {0}.", objectUri );
      Console::WriteLine( "The channel URI is {0}.", channelUri );
      Console::WriteLine( "The object URL is {0}.", objectUrl );
   }

   // Wait for the user prompt.
   Console::WriteLine( "Press enter to terminate the server." );
   Console::ReadLine();
}
