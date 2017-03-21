#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
void main()
{
   // Create the channel.
   HttpClientChannel^ clientChannel = gcnew HttpClientChannel;

   // Register the channel.
   ChannelServices::RegisterChannel( clientChannel );

   // Register as client for remote object.
   WellKnownClientTypeEntry^ remoteType = gcnew WellKnownClientTypeEntry( RemoteObject::typeid,L"http://localhost:9090/RemoteObject.rem" );
   RemotingConfiguration::RegisterWellKnownClientType( remoteType );

   // Create a message sink.
   String^ objectUri;
   System::Runtime::Remoting::Messaging::IMessageSink^ messageSink = clientChannel->CreateMessageSink( L"http://localhost:9090/RemoteObject.rem", nullptr,  objectUri );
   Console::WriteLine( L"The URI of the message sink is {0}.", objectUri );
   if ( messageSink != nullptr )
   {
      Console::WriteLine( L"The type of the message sink is {0}.", messageSink->GetType() );
   }

   // Display the channel's properties using Keys and Item.
   for each(String^ key in clientChannel->Keys)
   {
       Console::WriteLine("clientChannel[{0}] = <{1}>", key, clientChannel[key]);
   }

   // Parse the channel's URI.
   String^ objectUrl = L"http://localhost:9090/RemoteObject.rem";
   String^ channelUri = clientChannel->Parse( objectUrl,  objectUri );
   Console::WriteLine( L"The object URL is {0}.", objectUrl );
   Console::WriteLine( L"The object URI is {0}.", objectUri );
   Console::WriteLine( L"The channel URI is {0}.", channelUri );

   // Create an instance of the remote object.
   RemoteObject^ service = gcnew RemoteObject;
   
   // Invoke a method on the remote object.
   Console::WriteLine( L"The client is invoking the remote object." );
   Console::WriteLine( L"The remote object has been called {0} times.", service->GetCount() );
}