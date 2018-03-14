/// Class: System.Runtime.Remoting.Channels.Ipc.IpcClientChannel
/// 41 #ctor(IDictionary,IClientChannelSinkProvider)
/// 42 #ctor(String,IClientChannelSinkProvider)
/// 21 ChannelName
/// 23 ChannelPriority
/// 22 CreateMessageSink(String,Object,String@) 
/// 24 Parse(String,String@)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

void main()
{
   
   // Create the channel.
   IpcClientChannel^ clientChannel = gcnew IpcClientChannel;
   
   // Register the channel.
   System::Runtime::Remoting::Channels::ChannelServices::RegisterChannel(clientChannel);
   
   //<snippet21>
   // Show the name of the channel.
   Console::WriteLine( L"The name of the channel is {0}.", clientChannel->ChannelName );
   
   //</snippet21>
   //<snippet23>
   // Show the priority of the channel.
   Console::WriteLine( L"The priority of the channel is {0}.", clientChannel->ChannelPriority );
   
   //</snippet23>
   // Register as client for remote object.
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry(
      RemoteObject::typeid,L"ipc://localhost:9090/RemoteObject.rem" );
   System::Runtime::Remoting::RemotingConfiguration::RegisterWellKnownClientType(remoteType);
   
   //<snippet22>
   // Create a message sink.
   String^ messageSinkUri;
   Messaging::IMessageSink^ messageSink = clientChannel->CreateMessageSink(
      L"ipc://localhost:9090/RemoteObject.rem", nullptr,  messageSinkUri );
   Console::WriteLine( L"The URI of the message sink is {0}.", messageSinkUri );
   if ( messageSink != nullptr )
   {
      Console::WriteLine( L"The type of the message sink is {0}.", messageSink->GetType() );
   }

   
   //</snippet22>
   //<snippet24>
   // Parse the object URL.
   String^ objectUrl = L"ipc://localhost:9090/RemoteObject.rem";
   String^ objectUri;
   String^ channelUri = clientChannel->Parse( objectUrl,  objectUri );
   Console::WriteLine( L"The object URL is {0}.", objectUrl );
   Console::WriteLine( L"The object URI is {0}.", objectUri );
   Console::WriteLine( L"The channel URI is {0}.", channelUri );
   
   //</snippet24>
   // Create an instance of the remote object.
   RemoteObject^ service = gcnew RemoteObject;
   
   // Invoke a method on the remote object.
   Console::WriteLine( L"The client is invoking the remote object." );
   Console::WriteLine( L"The remote object has been called {0} times.", service->GetCount() );
}

