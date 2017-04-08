

// System.Runtime.Remoting.Channels.Http.HttpClientChannel
// System.Runtime.Remoting.Channels.Http.HttpClientChannel.ChannelName; System.Runtime.Remoting.Channels.Http.HttpClientChannel.ChannelPriority; System.Runtime.Remoting.Channels.Http.HttpClientChannel.Parse(); System.Runtime.Remoting.Channels.Http.HttpClientChannel.Keys; System.Runtime.Remoting.Channels.Http.HttpClientChannel.CreateMessageSink()
/*
The following program demonstrates the 'HttpClientChannel' class and
'ChannelName','ChannelPriority' , 'Keys', properties, and 'Parse',
CreateMessageSink methods of 'HttpClientChannel' class. This program 
create and registers 'HttpClientChannel'. This will change the priority
of the 'HttpClientChannel' channel and it displays the property values 
of 'HttpClientChannel'.
*/
// <Snippet4>
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <HttpServerChannel_Clientl_14_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Collections;
using namespace System::Runtime::Remoting::Messaging;

int main()
{
   try
   {
      // <Snippet5>
      // Creating the 'IDictionary' to set the server object properties.
      IDictionary^ myDictionary = gcnew Hashtable;
      myDictionary[ "name" ] = "HttpClientChannel";
      myDictionary[ "priority" ] = 2;

      // Set the properties along with the constructor.
      HttpClientChannel^ myHttpClientChannel = gcnew HttpClientChannel( myDictionary,gcnew BinaryClientFormatterSinkProvider );

      // Register the server channel.
      ChannelServices::RegisterChannel( myHttpClientChannel );
      MyHelloServer ^ myHelloServer1 = dynamic_cast<MyHelloServer^>(Activator::GetObject( MyHelloServer::typeid, "http://localhost:8085/SayHello" ));
      if ( myHelloServer1 == nullptr )
            System::Console::WriteLine( "Could not locate server" );
      else
      {
         Console::WriteLine( myHelloServer1->myHelloMethod( "Client" ) );

         // Get the name of the channel.
         Console::WriteLine( "Channel Name :{0}", myHttpClientChannel->ChannelName );

         // Get the channel priority.
         Console::WriteLine( "ChannelPriority :{0}", myHttpClientChannel->ChannelPriority );
         String^ myString;
         String^ myObjectURI1;
         Console::WriteLine( "Parse :{0}{1}", myHttpClientChannel->Parse( "http://localhost:8085/SayHello",  myString ), myString );

         // Get the key count.
         System::Console::WriteLine( "Keys->Count : {0}", myHttpClientChannel->Keys->Count );

         // Get the channel message sink that delivers message to the specified url.
         IMessageSink^ myIMessageSink = myHttpClientChannel->CreateMessageSink( "http://localhost:8085/NewEndPoint", nullptr,  myObjectURI1 );
         Console::WriteLine( "The channel message sink that delivers the messages to the URL is : {0}", myIMessageSink );
         Console::WriteLine( "URI of the new channel message sink is: {0}", myObjectURI1 );
      }
   // </Snippet5>
   }
   catch ( Exception^ ex ) 
   {
      Console::WriteLine( "The following exception is raised on client side :{0}", ex->Message );
   }
}
// </Snippet4>
