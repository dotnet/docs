

// System.Runtime.Remoting.Channels.ChannelServices.GetChannel
// System.Runtime.Remoting.Channels.ChannelServices.GetChannelSinkProperties
/*
This example demonstrates the usage of the properties 'GetChannel' and 
'GetChannelSinkProperties' of the 'ChannelServices' class. It displays
the registered channel name, priority and channelsinkproperties
for a given proxy and executes a remote method 'HelloMethod'.
*/
#using <System.Runtime.Remoting.dll>
#using <System.dll>
#using <ChannelServices_GetChannel_Share.dll>

using namespace System;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;
using namespace System::Collections;
using namespace System::Collections::Specialized;
int main()
{
   ListDictionary^ myProperties = gcnew ListDictionary;
   myProperties->Add( "port", 8085 );
   myProperties->Add( "name", "MyHttpChannel" );
   
   // <Snippet1>
   HttpChannel^ myClientChannel = gcnew HttpChannel( myProperties,gcnew SoapClientFormatterSinkProvider,gcnew SoapServerFormatterSinkProvider );
   ChannelServices::RegisterChannel( myClientChannel, false );
   
   // Get the registered channel. 
   Console::WriteLine( "Channel Name : {0}", ChannelServices::GetChannel( myClientChannel->ChannelName )->ChannelName );
   Console::WriteLine( "Channel Priorty : {0}", ChannelServices::GetChannel( myClientChannel->ChannelName )->ChannelPriority );
   
   // </Snippet1>
   RemotingSamples::HelloServer^ myProxy = dynamic_cast<RemotingSamples::HelloServer^>(Activator::GetObject( RemotingSamples::HelloServer::typeid, "http://localhost:8086/SayHello" ));
   
   // <Snippet2>
   // Get an IDictionary of properties for a given proxy.
   IDictionary^ myDictionary = ChannelServices::GetChannelSinkProperties( myProxy );
   ICollection^ myKeysCollection = myDictionary->Keys;
   array<Object^>^myKeysArray = gcnew array<Object^>(myKeysCollection->Count);
   ICollection^ myValuesCollection = myDictionary->Values;
   array<Object^>^myValuesArray = gcnew array<Object^>(myValuesCollection->Count);
   myKeysCollection->CopyTo( myKeysArray, 0 );
   myValuesCollection->CopyTo( myValuesArray, 0 );
   for ( int iIndex = 0; iIndex < myKeysArray->Length; iIndex++ )
   {
      Console::WriteLine( "Property Name : {0} value : {1}", myKeysArray[ iIndex ], myValuesArray[ iIndex ] );

   }
   // </Snippet2>
   if ( myProxy == nullptr )
      System::Console::WriteLine( "Could not locate server" );
   else
      Console::WriteLine( myProxy->HelloMethod( "Caveman" ) );
}
