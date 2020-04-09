/// Class: System.Runtime.Remoting.Channels.Ipc.IpcServerChannel
/// 41 #ctor(IDictionary,IServerChannelSinkProvider)
/// 42 #ctor(String,String)
/// 43 #ctor(String,String,IServerChannelSinkProvider)
/// 15 ChannelData
/// 12 ChannelName
/// 13 ChannelPriority
/// 19 GetUrlsForUri
/// 19 Parse(String,String@)
/// !  StartListening(Object)
/// !  StopListening(Object)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

void main()
{
   // Create the server channel.
   IpcServerChannel^ serverChannel = gcnew IpcServerChannel( L"localhost:9090" );
   
   // Register the server channel.
   System::Runtime::Remoting::Channels::ChannelServices::RegisterChannel( serverChannel );
   
   //<snippet12>
   // Show the name of the channel.
   Console::WriteLine( L"The name of the channel is {0}.",serverChannel->ChannelName );
   //</snippet12>

   //<snippet13>
   // Show the priority of the channel.
   Console::WriteLine( L"The priority of the channel is {0}.",serverChannel->ChannelPriority );
   //</snippet13>

   //<snippet15>
   // Show the URIs associated with the channel.
   System::Runtime::Remoting::Channels::ChannelDataStore^ channelData = 
      static_cast<System::Runtime::Remoting::Channels::ChannelDataStore^>
         (serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = channelData->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>( myEnum->Current );
      Console::WriteLine( L"The channel URI is {0}.",uri );
   }
   //</snippet15>
   
   // Expose an object for remote calls.
   System::Runtime::Remoting::RemotingConfiguration::
      RegisterWellKnownServiceType(
         RemoteObject::typeid,L"RemoteObject.rem",
         System::Runtime::Remoting::WellKnownObjectMode::Singleton );
   
   //<snippet19>
   // Parse the channel's URI.
   array<String^>^urls = serverChannel->GetUrlsForUri( L"RemoteObject.rem" );
   if ( urls->Length > 0 )
   {
      String^ objectUrl = urls[ 0 ];
      String^ objectUri;
      String^ channelUri = serverChannel->Parse( objectUrl,objectUri );
      Console::WriteLine( L"The object URI is {0}.",objectUri );
      Console::WriteLine( L"The channel URI is {0}.",channelUri );
      Console::WriteLine( L"The object URL is {0}.",objectUrl );
   }
   //</snippet19>

   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}

