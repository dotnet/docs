

// System.Runtime.Remoting.Channels.Http.HttpServerChannel
// System.Runtime.Remoting.Channels.Http.HttpServerChannel.StartListening(); System.Runtime.Remoting.Channels.Http.HttpServerChannel.ChannelName; System.Runtime.Remoting.Channels.Http.HttpServerChannel.ChannelPriority; System.Runtime.Remoting.Channels.Http.HttpServerChannel.ChannelScheme; System.Runtime.Remoting.Channels.Http.HttpServerChannel.GetChannelUri(); System.Runtime.Remoting.Channels.Http.HttpServerChannel.WantsToListen
// System.Runtime.Remoting.Channels.Http.HttpServerChannel.Parse(); System.Runtime.Remoting.Channels.Http.HttpServerChannel.StopListening()
/* The following program demonstrates the 'HttpServerChannel' class, 'ChannelName',
'ChannelPriority', 'ChannelScheme', 'WantsToListen' properties, 'GetChannelUri',
'StartListening', 'StopListening' and 'Parse' methods of 'HttpServerChannel' class. 
This program creates and registers 'HttpServerChannel'. This will change the priority 
of the 'HttpServerChannel' channel and displays the property values of this class.
*/
// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <HttpServerChannel_Clientl_14_Share.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
int main()
{
   try
   {
      String^ myString;

      // <Snippet2>
      int myPort = 8085;

      // Creating the 'IDictionary' to set the server object properties.
      IDictionary^ myDictionary = gcnew Hashtable;
      myDictionary[ "name" ] = "MyServerChannel1";
      myDictionary[ "priority" ] = 2;
      myDictionary[ "port" ] = 8085;

      // Set the properties along with the constructor.
      HttpServerChannel^ myHttpServerChannel = gcnew HttpServerChannel( myDictionary,gcnew BinaryServerFormatterSinkProvider );

      // Register the server channel.
      ChannelServices::RegisterChannel( myHttpServerChannel );
      RemotingConfiguration::RegisterWellKnownServiceType( MyHelloServer::typeid, "SayHello", WellKnownObjectMode::SingleCall );
      myHttpServerChannel->WantsToListen = true;

      // Start listening on a specific port.
      myHttpServerChannel->StartListening( myPort );

      // Get the name of the channel.
      Console::WriteLine( "ChannelName : {0}", myHttpServerChannel->ChannelName );

      // Get the channel priority.
      Console::WriteLine( "ChannelPriority : {0}", myHttpServerChannel->ChannelPriority );

      // Get the schema of the channel.
      Console::WriteLine( "ChannelScheme : {0}", myHttpServerChannel->ChannelScheme );

      // Get the channel URI.
      Console::WriteLine( "GetChannelUri : {0}", myHttpServerChannel->GetChannelUri() );

      // Indicates whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
      Console::WriteLine( "WantsToListen : {0}", myHttpServerChannel->WantsToListen );
      // </Snippet2>

      // <Snippet3>
      // Extract the channel URI and the remote well known object URI from the specified URL.
      Console::WriteLine( "Parsed : {0}", myHttpServerChannel->Parse( String::Concat( myHttpServerChannel->GetChannelUri(), "/SayHello" ),  myString ) );
      Console::WriteLine( "Remote WellKnownObject : {0}", myString );
      Console::WriteLine( "Hit <enter> to stop listening..." );
      Console::ReadLine();

      // Stop listening to channel.
      myHttpServerChannel->StopListening( myPort );
      // </Snippet3>

      Console::WriteLine( "Hit <enter> to exit..." );
      Console::ReadLine();
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "The following exception is raised on server side : {0}", ex->Message );
   }

}
// </Snippet1>
