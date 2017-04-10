/// Class: System.Runtime.Remoting.Channels.Ipc.IpcServerChannel
/// 41 #ctor(IDictionary,IServerChannelSinkProvider)
/// 42 #ctor(String,String)
/// 43 #ctor(String,String,IServerChannelSinkProvider)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Ipc;

static IpcServerChannel^ Ctor1()
{
   //<snippet41>
   // Create the server channel.
   System::Collections::IDictionary^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"name" ] = L"ipc";
   properties->default[ L"priority" ] = L"20";
   properties->default[ L"portName" ] = L"localhost:9090";
   IpcServerChannel^ serverChannel = gcnew IpcServerChannel( properties, nullptr );
   
   //</snippet41>
   return serverChannel;
}

static IpcServerChannel^ Ctor2()
{
   //<snippet42>
   // Create the server channel.
   String^ name = L"ipc";
   String^ portName = L"localhost:9090";
   IpcServerChannel^ serverChannel = gcnew IpcServerChannel( name,portName );
   
   //</snippet42>
   return serverChannel;
}

static IpcServerChannel^ Ctor3()
{
   //<snippet43>
   // Create the server channel.
   String^ name = L"ipc";
   String^ portName = L"localhost:9090";
   IServerChannelSinkProvider^ sinkProvider = nullptr;
   IpcServerChannel^ serverChannel = gcnew IpcServerChannel( name,portName,sinkProvider );
   
   //</snippet43>
   return serverChannel;
}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   
   // Create the server channel.
   IpcServerChannel^ serverChannel = nullptr;
   if ( false ) {}
   else if ( args[ 1 ]->Equals( L"1" ) ) serverChannel = Ctor1();
   else if ( args[ 1 ]->Equals( L"2" ) ) serverChannel = Ctor2();
   else if ( args[ 1 ]->Equals( L"3" ) ) serverChannel = Ctor3();
   else throw gcnew ApplicationException( L"Invalid argument." );

   // Register the server channel.
   ChannelServices::RegisterChannel( serverChannel );
   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType(
      RemoteObject::typeid, L"RemoteObject.rem",
      WellKnownObjectMode::Singleton );
   
   // Show the URIs associated with the channel.
   ChannelDataStore^ channelData = static_cast<ChannelDataStore^>(serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = channelData->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = static_cast<String^>(myEnum->Current);
      Console::WriteLine( L"The channel URI is {0}.", uri );
   }
   
   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}

