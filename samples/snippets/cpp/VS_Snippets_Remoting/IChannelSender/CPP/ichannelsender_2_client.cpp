

// System.Runtime.Remoting.Channels.IChannelSender
// System.Runtime.Remoting.Channels.IChannelSender.CreateMessageSink()
/* The following program demonstrates the usage of IChannelSender 
interface and its 'CreateMessageSink' method in the namespace
'System.Runtime.Remoting.Channels'. This program creates and
registers an IChannelSender of type 'HttpClientChannel'.
It sets the priority of the channel and it displays the
property values of 'HttpClientChannel'. */
// <Snippet1>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <IChannelSender_Share.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Runtime::Remoting::Channels::Http;
int main()
{
   try
   {
      
      // Create the 'IDictionary' to set the server object properties.
      IDictionary^ myDictionary = gcnew Hashtable;
      myDictionary->default[ "name" ] = "HttpClientChannel";
      myDictionary->default[ "priority" ] = 2;
      
      // Set the properties along with the constructor.
      IChannelSender^ myIChannelSender = gcnew HttpClientChannel( myDictionary,gcnew BinaryClientFormatterSinkProvider );
      
      // Register the server channel.
      ChannelServices::RegisterChannel( myIChannelSender, false );
	  MyHelloServer ^ myHelloServer1 = dynamic_cast<MyHelloServer^>(Activator::GetObject( MyHelloServer::typeid, "http://localhost:8085/SayHello" ));
      if ( myHelloServer1 == nullptr )
      {
         Console::WriteLine( "Could not locate server" );
      }
      else
      {
         Console::WriteLine( myHelloServer1->myHelloMethod( "Client" ) );
         
         // Get the name of the channel.
         Console::WriteLine( "Channel Name :{0}", myIChannelSender->ChannelName );
         
         // Get the channel priority.
         Console::WriteLine( "ChannelPriority :{0}", myIChannelSender->ChannelPriority );
         String^ myString;
         String^ myObjectURI1;
         Console::WriteLine( "Parse :{0}{1}", myIChannelSender->Parse( "http://localhost:8085/SayHello",  myString ), myString );
         
         // <Snippet2>
         // Get the channel message sink that delivers message to specified url.
         IMessageSink^ myIMessageSink = myIChannelSender->CreateMessageSink( "http://localhost:8085/NewEndPoint", nullptr,  myObjectURI1 );
         Console::WriteLine( "Channel message sink used :{0}", myIMessageSink );
         
         // </Snippet2>
         Console::WriteLine( "URI of new channel message sink :{0}", myObjectURI1 );
      }
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "Following exception is raised on client side : {0}", ex->Message );
   }

}

// </Snippet1>
