#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <Remotable.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   // Set up a server channel.
   TcpServerChannel^ serverChannel = gcnew TcpServerChannel( 9090 );
   ChannelServices::RegisterChannel( serverChannel );

   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType( Remotable::typeid, "Remotable.rem", WellKnownObjectMode::Singleton );

   // Show the name and priority of the channel.
   Console::WriteLine( "Channel Name: {0}", serverChannel->ChannelName );
   Console::WriteLine( "Channel Priority: {0}", serverChannel->ChannelPriority );

   // Show the URIs associated with the channel.
   ChannelDataStore^ data = dynamic_cast<ChannelDataStore^>(serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = data->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( uri );
   }

   // Wait for method calls.
   Console::WriteLine( "Listening..." );
   Console::ReadLine();
}