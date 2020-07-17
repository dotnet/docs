/// Class: System.Runtime.Remoting.Channels.Ipc.IpcChannel
/// 41 #ctor(IDictionary,IClientChannelSinkProvider,IServerChannelSinkProvider)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

void main()
{
   
   //<snippet41>
   // Create the server channel.
   System::Collections::IDictionary^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"name" ] = L"ipc";
   properties->default[ L"priority" ] = L"20";
   properties->default[ L"portName" ] = L"localhost:9090";
   IpcChannel^ serverChannel = gcnew IpcChannel( properties,nullptr,nullptr );
   
   //</snippet41>
   // Register the server channel.
   ChannelServices::RegisterChannel( serverChannel );
   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType( 
      RemoteObject::typeid, L"RemoteObject.rem", WellKnownObjectMode::Singleton );
   
   // Show the URIs associated with the channel.
   ChannelDataStore^ channelData = dynamic_cast<ChannelDataStore^>(serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = channelData->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( L"The channel URI is {0}.", uri );
   }

   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}

