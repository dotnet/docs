#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

int main()
{
   // Create the server channel.
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel( 9090 );
   
   // Register the server channel.
   ChannelServices::RegisterChannel( serverChannel );
   
   // Display the channel's scheme.
   Console::WriteLine( L"The channel scheme is {0}.", serverChannel->ChannelScheme );
   
   // Display the channel's URI.
   Console::WriteLine( L"The channel URI is {0}.", serverChannel->GetChannelUri() );
   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType(
      RemoteObject::typeid, L"RemoteObject.rem", WellKnownObjectMode::Singleton );
   
   // Get the channel's sink chain.
   IServerChannelSink^ sinkChain = serverChannel->ChannelSinkChain;
   Console::WriteLine( L"The type of the server channel's sink chain is {0}.", sinkChain->GetType() );
   
   // See if the channel wants to listen.
   bool wantsToListen = serverChannel->WantsToListen;
   Console::WriteLine( L"The value of WantsToListen is {0}.", wantsToListen );
   
   // Parse the channel's URI.
   array<String^>^ urls = serverChannel->GetUrlsForUri( L"RemoteObject.rem" );
   if ( urls->Length > 0 )
   {
      String^ objectUrl = urls[ 0 ];
      String^ objectUri;
      String^ channelUri = serverChannel->Parse( objectUrl,  objectUri );
      Console::WriteLine( L"The object URI is {0}.", objectUri );
      Console::WriteLine( L"The channel URI is {0}.", channelUri );
      Console::WriteLine( L"The object URL is {0}.", objectUrl );
   }

   
   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}
