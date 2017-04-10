

// class: System.Runtime.Remoting.Channels.Tcp.TcpClientChannel
// client.cs:
//        Ctor(string, IClientChannelSinkProvider)
//        CreateMessageSink
//        Parse
//<snippet30>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "common.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   
   //<snippet31>
   // Create the channel.
   TcpClientChannel^ clientChannel = gcnew TcpClientChannel( "Client",nullptr );
   
   //</snippet31>
   // Register the channel.
   ChannelServices::RegisterChannel( clientChannel );
   
   // Register as client for remote object.
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry( RemoteObject::typeid,"tcp://localhost:9090/RemoteObject.rem" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );
   
   //<snippet32>
   // Create a message sink.
   String^ objectUri;
   System::Runtime::Remoting::Messaging::IMessageSink^ messageSink = clientChannel->CreateMessageSink( "tcp://localhost:9090/RemoteObject.rem", nullptr, objectUri );
   Console::WriteLine( "The URI of the message sink is {0}.", objectUri );
   Console::WriteLine( "The type of the message sink is {0}.", messageSink->GetType() );
   
   //</snippet32>
   //<snippet33>
   // Parse the channel's URI.
   String^ objectUrl = "tcp://localhost:9090/RemoteObject.rem";
   String^ channelUri = clientChannel->Parse( objectUrl, objectUri );
   Console::WriteLine( "The object URL is {0}.", objectUrl );
   Console::WriteLine( "The object URI is {0}.", objectUri );
   Console::WriteLine( "The channel URI is {0}.", channelUri );
   
   //</snippet33>
   // Create an instance of the remote object.
   RemoteObject^ service = gcnew RemoteObject;
   
   // Invoke a method on the remote object.
   Console::WriteLine( "The client is invoking the remote object." );
   Console::WriteLine( "The remote object has been called {0} times.", service->GetCount() );
}

//</snippet30>
