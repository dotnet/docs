/// Class:  System.Runtime.Remoting.Channels.Http.HttpServerChannel
///    20    class - server
///    30    class - client
///    40    class - remotable object
///    12    ctor(IDictionary,IServerChannelSinkProvider)
///    13    ctor(string,int)
///    14    ctor(string,int,IServerChannelSinkProvider)
///    21    ChannelScheme
///    23    ChannelSinkChain
///    22    GetChannelUri()
///    25    Parse()
///    24    WantsToListen
///    !    Ctor()
///    !    AddHookChannelUri
///    !    Item
///    !    Keys
///    !    StartListening
///    !    StopListening
/// Bug Notes [01-26-04][Mon]
/// AddHookChannelUri does not pick up port.
/// Ctor() would be usable if AddHookChannelUri could be 
/// used to set the port later. Since it can't Ctor() is
/// also unusable. Items and Keys are unimplemented. While
/// StopListening works, StartListening does not restart
/// listening -- client fails. These two are likely to be 
/// used as a pair and are therefore unusable.
//<snippet20>
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
   
   //<snippet21>
   // Display the channel's scheme.
   Console::WriteLine( L"The channel scheme is {0}.", serverChannel->ChannelScheme );
   
   //</snippet21>
   //<snippet22>
   // Display the channel's URI.
   Console::WriteLine( L"The channel URI is {0}.", serverChannel->GetChannelUri() );
   
   //</snippet22>
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType(
      RemoteObject::typeid, L"RemoteObject.rem", WellKnownObjectMode::Singleton );
   
   //<snippet23>
   // Get the channel's sink chain.
   IServerChannelSink^ sinkChain = serverChannel->ChannelSinkChain;
   Console::WriteLine( L"The type of the server channel's sink chain is {0}.", sinkChain->GetType() );
   
   //</snippet23>
   //<snippet24>
   // See if the channel wants to listen.
   bool wantsToListen = serverChannel->WantsToListen;
   Console::WriteLine( L"The value of WantsToListen is {0}.", wantsToListen );
   
   //</snippet24>
   //<snippet25>
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

   
   //</snippet25>
   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}

//</snippet20>
