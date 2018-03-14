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

static IpcClientChannel^ Ctor1()
{
   //<snippet41>
   // Create the client channel.
   System::Collections::IDictionary^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"name" ] = L"ipc client";
   properties->default[ L"priority" ] = L"1";
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   IpcClientChannel^ clientChannel = gcnew IpcClientChannel( properties,sinkProvider );
   //</snippet41>

   return clientChannel;
}

static IpcClientChannel^ Ctor2()
{
   //<snippet42>
   // Create the client channel.
   String^ name = L"ipc client";
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   IpcClientChannel^ clientChannel = gcnew IpcClientChannel( name,sinkProvider );
   //</snippet42>

   return clientChannel;
}

void main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   
   // Create the client channel.
   IpcClientChannel^ clientChannel = nullptr;
//   if ( false ) {}
//   else
   if ( args[ 1 ]->Equals( L"1" ) )
      clientChannel = Ctor1();
   else
   if ( args[ 1 ]->Equals( L"2" ) )
      clientChannel = Ctor2();
   else
      throw gcnew ApplicationException( L"Invalid argument." );
   
   // Register the channel.
   ChannelServices::RegisterChannel( clientChannel );
   
   // Register as client for remote object.
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry(
      RemoteObject::typeid,L"ipc://localhost:9090/RemoteObject.rem" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );
   
   // Create an instance of the remote object.
   RemoteObject^ service = gcnew RemoteObject;
   
   // Invoke a method on the remote object.
   Console::WriteLine( L"The client is invoking the remote object." );
   Console::WriteLine( L"The remote object has been called {0} times.", service->GetCount() );
}

