/// Class: System.Runtime.Remoting.Channels.Tcp.TcpServerChannel
///    21    Ctor(string, int, IServerChannelSinkProvider)
///    22    GetChannelUri();
///    23    Parse();
///    !    Ctor(string, int)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

void main()
{
   //<snippet21>
   // Create the server channel.
   TcpServerChannel^ channel = gcnew TcpServerChannel( 
      L"Server Channel",9090,nullptr );
   //</snippet21>

   // Register the server channel.
   ChannelServices::RegisterChannel( channel );
   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType(
      RemoteObject::typeid, L"RemoteObject.rem", 
      WellKnownObjectMode::Singleton );
   
   //<snippet22>
   // Display the channel's URI.
   Console::WriteLine( L"The channel URI is {0}.",
      channel->GetChannelUri() );
   //</snippet22>

   //<snippet23>
   // Parse the channel's URI.
   array<String^>^urls = channel->GetUrlsForUri( L"RemoteObject.rem" );
   if ( urls->Length > 0 )
   {
      String^ objectUrl = urls[ 0 ];
      String^ objectUri;
      String^ channelUri = channel->Parse( objectUrl,  objectUri );
      Console::WriteLine( L"The object URI is {0}.", objectUri );
      Console::WriteLine( L"The channel URI is {0}.", channelUri );
      Console::WriteLine( L"The object URL is {0}.", objectUrl );
   }
   //</snippet23>

   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}

