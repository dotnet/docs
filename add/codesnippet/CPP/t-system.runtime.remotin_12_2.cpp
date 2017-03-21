#using <System.dll>
#using <System.Runtime.Remoting.dll>
#using "common.dll"
using namespace System;
using namespace System::Runtime::Remoting::Channels::Ipc;

void main()
{
   
   // Create the channel.
   IpcChannel^ channel = gcnew IpcChannel;
   
   // Register the channel.
   System::Runtime::Remoting::Channels::ChannelServices::RegisterChannel(channel);
   
   // Register as client for remote object.
   System::Runtime::Remoting::WellKnownClientTypeEntry^ remoteType = gcnew
       System::Runtime::Remoting::WellKnownClientTypeEntry( 
         RemoteObject::typeid,L"ipc://localhost:9090/RemoteObject.rem" );
   System::Runtime::Remoting::RemotingConfiguration::RegisterWellKnownClientType(remoteType);
   
   // Create a message sink.
   String^ objectUri;
   System::Runtime::Remoting::Messaging::IMessageSink^ messageSink = channel->CreateMessageSink(
      L"ipc://localhost:9090/RemoteObject.rem", nullptr, objectUri );
   Console::WriteLine( L"The URI of the message sink is {0}.", objectUri );
   if ( messageSink != nullptr )
   {
      Console::WriteLine( L"The type of the message sink is {0}.", messageSink->GetType() );
   }

   
   // Create an instance of the remote object.
   RemoteObject^ service = gcnew RemoteObject;
   
   // Invoke a method on the remote object.
   Console::WriteLine( L"The client is invoking the remote object." );
   Console::WriteLine( L"The remote object has been called {0} times.", service->GetCount() );
}
