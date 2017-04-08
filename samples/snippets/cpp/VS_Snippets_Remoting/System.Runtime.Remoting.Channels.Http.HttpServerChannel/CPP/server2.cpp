/// Legend:
/// -    Bugs
/// x    Done
///        Work in progress
/// Snippets needed: 
///    -    Ctor()
///    x    Ctor(IDictionary,IServerChannelSinkProvider)
///    x    Ctor(string,int)
///    x    Ctor(string,int,IServerChannelSinkProvider)
#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

static HttpServerChannel^ Ctor2()
{
   //<snippet12>
   System::Collections::Hashtable^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"port" ] = 9090;
   IServerChannelSinkProvider^ sinkProvider = nullptr;
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel( properties,sinkProvider );
   
   //</snippet12>
   return serverChannel;
}

// Broken.
static HttpServerChannel^ Ctor1()
{
   //<snippet11>
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel;
   serverChannel->AddHookChannelUri( L"http://localhost:9090" );
   
   //</snippet11>
   // return serverChannel; 
   // Return good channel until fix.
   return Ctor2();
}

static HttpServerChannel^ Ctor3()
{
   //<snippet13>
   String^ name = L"RemotingServer";
   int port = 9090;
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel( name,port );
   
   //</snippet13>
   return serverChannel;
}

static HttpServerChannel^ Ctor4()
{
   
   //<snippet14>
   String^ name = L"RemotingServer";
   int port = 9090;
   IServerChannelSinkProvider^ sinkProvider = nullptr;
   HttpServerChannel^ serverChannel = gcnew HttpServerChannel(
      name,port,sinkProvider );
   
   //</snippet14>
   return serverChannel;
}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   HttpServerChannel^ serverChannel = nullptr;
   String^ overload = args[ 1 ];
   if ( overload->Equals( L"1" ) ) serverChannel = Ctor1();
   else if ( overload->Equals( L"2" ) ) serverChannel = Ctor2();
   else if ( overload->Equals( L"3" ) ) serverChannel = Ctor3();
   else if ( overload->Equals( L"4" ) ) serverChannel = Ctor4();
   else throw gcnew Exception( String::Format(
      L"Argument {0} was invalid.", args[ 1 ] ) );
   
   // Register the server channel.
   ChannelServices::RegisterChannel( serverChannel );
   
   // Display the channel's URI.
   Console::WriteLine( L"The URI of the channel is {0}.", 
      serverChannel->GetChannelUri() );
   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType(
      RemoteObject::typeid, L"RemoteObject.rem",
      WellKnownObjectMode::Singleton );
   
   // Wait for the user prompt.
   Console::WriteLine( L"Press ENTER to exit the server." );
   Console::ReadLine();
   Console::WriteLine( L"The server is exiting." );
}

