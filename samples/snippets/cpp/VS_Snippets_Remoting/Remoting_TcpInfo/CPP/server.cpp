

// <snippet30>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <Remotable.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Tcp;

int main()
{
   // <snippet31>
   // Set up a server channel.
   TcpServerChannel^ serverChannel = gcnew TcpServerChannel( 9090 );
   ChannelServices::RegisterChannel( serverChannel );
   // </snippet31>

   // Expose an object for remote calls.
   RemotingConfiguration::RegisterWellKnownServiceType( Remotable::typeid, "Remotable.rem", WellKnownObjectMode::Singleton );

   // <snippet32>
   // Show the name and priority of the channel.
   Console::WriteLine( "Channel Name: {0}", serverChannel->ChannelName );
   Console::WriteLine( "Channel Priority: {0}", serverChannel->ChannelPriority );
   // </snippet32>

   // <snippet33>
   // Show the URIs associated with the channel.
   ChannelDataStore^ data = dynamic_cast<ChannelDataStore^>(serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = data->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( uri );
   }
   // </snippet33> 

   // Wait for method calls.
   Console::WriteLine( "Listening..." );
   Console::ReadLine();
}
// </snippet30>
