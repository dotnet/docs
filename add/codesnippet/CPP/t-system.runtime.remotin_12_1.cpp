#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting::Channels::Ipc;

void main()
{
   // Create the server channel.
   IpcChannel^ serverChannel = gcnew IpcChannel( L"localhost:9090" );

   // Register the server channel.
   System::Runtime::Remoting::Channels::ChannelServices::RegisterChannel( serverChannel );

   // Show the name of the channel.
   Console::WriteLine( L"The name of the channel is {0}.", serverChannel->ChannelName );

   // Show the priority of the channel.
   Console::WriteLine( L"The priority of the channel is {0}.", serverChannel->ChannelPriority );

   // Show the URIs associated with the channel.
   System::Runtime::Remoting::Channels::ChannelDataStore^ channelData = (System::Runtime::Remoting::Channels::ChannelDataStore^)serverChannel->ChannelData;
   for each (String^ uri in channelData->ChannelUris)
   {
      Console::WriteLine("The channel URI is {0}.", uri);
   }
   
   // Expose an object for remote calls.
   System::Runtime::Remoting::RemotingConfiguration::RegisterWellKnownServiceType(
         RemoteObject::typeid,L"RemoteObject.rem",
         System::Runtime::Remoting::WellKnownObjectMode::Singleton);
   
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