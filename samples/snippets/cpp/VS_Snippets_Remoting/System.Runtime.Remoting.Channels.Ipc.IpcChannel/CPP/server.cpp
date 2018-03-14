/// Class: System.Runtime.Remoting.Channels.Ipc.IpcChannel
/// 10 class - Server.cs
/// 20 class - Client.cs
/// 30 class - Common.cs
/// 21 #ctor()
/// 11 #ctor(string)
/// 41 #ctor(IDictionary,IClientChannelSinkProvider,IServerChannelSinkProvider)
/// 15 ChannelData
/// 12 ChannelName
/// 13 ChannelPriority
/// 22 CreateMessageSink()
/// 19 GetUrlsForUri()
/// 19 Parse()
/// !  StartListening()
/// !  StopListening()
//<snippet10>
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting::Channels::Ipc;

void main()
{
   //<snippet11>
   // Create the server channel.
   IpcChannel^ serverChannel = gcnew IpcChannel( L"localhost:9090" );
   //</snippet11>

   // Register the server channel.
   System::Runtime::Remoting::Channels::ChannelServices::RegisterChannel( serverChannel );

   //<snippet12>
   // Show the name of the channel.
   Console::WriteLine( L"The name of the channel is {0}.", serverChannel->ChannelName );
   //</snippet12>

   //<snippet13>
   // Show the priority of the channel.
   Console::WriteLine( L"The priority of the channel is {0}.", serverChannel->ChannelPriority );
   //</snippet13>

   //<snippet15>
   // Show the URIs associated with the channel.
   System::Runtime::Remoting::Channels::ChannelDataStore^ channelData = (System::Runtime::Remoting::Channels::ChannelDataStore^)serverChannel->ChannelData;
   for each (String^ uri in channelData->ChannelUris)
   {
      Console::WriteLine("The channel URI is {0}.", uri);
   }
   //</snippet15>
   
   // Expose an object for remote calls.
   System::Runtime::Remoting::RemotingConfiguration::RegisterWellKnownServiceType(
         RemoteObject::typeid,L"RemoteObject.rem",
         System::Runtime::Remoting::WellKnownObjectMode::Singleton);
   
   //<snippet19>
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
   //</snippet19>

   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}
//</snippet10>
