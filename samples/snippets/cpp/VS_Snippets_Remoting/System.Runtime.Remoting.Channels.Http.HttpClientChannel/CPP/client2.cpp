
/// x    broken
/// +    done
/// 9    number of snippet
/// Need snippets:
///    21    #ctor(IDictionary,IClientChannelSinkProvider)
///    22    #ctor(string,sinkProvider)
///    11    CreateMessageSink
///    12    Item
///    12    Keys
///    13    Parse
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "common.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
static HttpClientChannel^ Ctor1()
{
   
   //<snippet21>
   // Create a client channel.
   System::Collections::Hashtable^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"port" ] = 9090;
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   HttpClientChannel^ clientChannel = gcnew HttpClientChannel( properties,sinkProvider );
   
   //</snippet21>
   return clientChannel;
}

static HttpClientChannel^ Ctor2()
{
   
   //<snippet22>
   // Create a client channel.
   String^ name = L"RemotingClient";
   IClientChannelSinkProvider^ sinkProvider = nullptr;
   HttpClientChannel^ clientChannel = gcnew HttpClientChannel( name,sinkProvider );
   
   //</snippet22>
   return clientChannel;
}

static void Register( HttpClientChannel^ channel )
{
   
   // Register the channel.
   ChannelServices::RegisterChannel( channel );
   
   // Register as client for remote object.
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry(
      RemoteObject::typeid, L"http://localhost:9090/RemoteObject.rem" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );
}

static void InvokeRemoteObject( RemoteObject^ service )
{
   
   // Invoke a method on the remote object.
   Console::WriteLine( L"The client is invoking the remote object." );
   Console::WriteLine( L"The remote object has been called {0} times.", service->GetCount() );
}

void main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   
   // Create the channel.
   HttpClientChannel^ clientChannel = nullptr;
   String^ overload = args[ 1 ];
   if ( overload->Equals( L"1" ) )
      clientChannel = Ctor1();
   else
   if ( overload->Equals( L"2" ) )
      clientChannel = Ctor2();
   else
      throw gcnew Exception( String::Format( L"Argument {0} was invalid.", args[ 1 ] ) );


   
   // Register the channel and the client.
   Register( clientChannel );
   
   // Create an instance of the remote object.
   RemoteObject^ service = gcnew RemoteObject;
   
   // Invoke a method on the remote object.
   InvokeRemoteObject( service );
}

