

//<snippet10>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using "common.dll"

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;
int main()
{
   
   // Create the server channel.
   TcpChannel^ serverChannel = gcnew TcpChannel( 9090 );
   
   // Register the server channel.
   ChannelServices::RegisterChannel( serverChannel );
   
   // Show the name of the channel.
   Console::WriteLine( "The name of the channel is {0}.", serverChannel->ChannelName );
   
   // Show the priority of the channel.
   Console::WriteLine( "The priority of the channel is {0}.", serverChannel->ChannelPriority );
   
   // Show the URIs associated with the channel.
   ChannelDataStore^ data = dynamic_cast<ChannelDataStore^>(serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = data->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( "The channel URI is {0}.", uri );
   }

   
   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType( RemoteObject::typeid, "RemoteObject.rem", WellKnownObjectMode::Singleton );
   
   // Wait for the user prompt.
   Console::WriteLine( "Press enter to terminate the server." );
   Console::ReadLine();
}

//</snippet10>
