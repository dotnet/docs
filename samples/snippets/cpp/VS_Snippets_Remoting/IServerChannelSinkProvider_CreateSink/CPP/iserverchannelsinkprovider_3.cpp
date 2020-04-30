// System.Runtime.Remoting.Channels.IServerChannelSinkProvider.CreateSink()
// System.Runtime.Remoting.Channels.IServerChannelSinkProvider.GetChannelData()
// System.Runtime.Remoting.Channels.IServerChannelSinkProvider.Next

/* The following program demonstrates 'CreateSink', 'GetChannelData' 
   methods and 'Next' property of 
   'System.Runtime.Remoting.Channels.ServerChannelSinkStack' class.
   It chains together two different sink providers using the 'Next'
   property. The return value of 'GetChannelData()' is displayed on
   the console.   
*/

#using <System.Runtime.Remoting.dll>
#using <System.dll>

using namespace System;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Channels::Http;

ref class MyServerChannelSinkStack
{
public:
   IServerChannelSinkProvider^ myIServerChannelSinkProvider;
   IServerChannelSinkProvider^ myIServerChannelSinkProvider1;
   IServerChannelSink^ myIServerChannelSink;
   IServerChannelSink^ myIServerChannelSink1;

   void MyCreateSinkMethod()
   {
      Console::Write( "Press Enter to set sink providers and create sinks" );
      Console::ReadLine();
      
// <Snippet1>
// <Snippet3>
      // Create the sink providers.
      myIServerChannelSinkProvider = gcnew SoapServerFormatterSinkProvider;
      myIServerChannelSinkProvider1 = gcnew BinaryServerFormatterSinkProvider;
      // Create the channel sinks.
      myIServerChannelSink = myIServerChannelSinkProvider->CreateSink( gcnew HttpChannel );
      myIServerChannelSinkProvider->Next = myIServerChannelSinkProvider1;

      myIServerChannelSink1 = myIServerChannelSinkProvider->Next->CreateSink( gcnew HttpChannel );
// </Snippet3>
// </Snippet1>
      Console::WriteLine( "Two sink providers have been set" );
   }

   void MyGetChannelDataMethod()
   {
// <Snippet2>
      array<String^>^channelUri = gcnew array<String^>(5);
      IChannelDataStore^ myIChannelDataStore = gcnew ChannelDataStore( channelUri );
      IChannelDataStore^ myIChannelDataStore1 = gcnew ChannelDataStore( channelUri );
      myIServerChannelSinkProvider->GetChannelData( myIChannelDataStore );
      myIServerChannelSinkProvider1->GetChannelData( myIChannelDataStore1 );
// </Snippet2>

      Console::WriteLine( "Number of Uris in first IChannelDataStore: {0}",
         myIChannelDataStore->ChannelUris->Length );
      Console::WriteLine( "Number of Uris in second IChannelDataStore: {0}",
         myIChannelDataStore1->ChannelUris->Length );
   }
};

int main()
{
   MyServerChannelSinkStack^ myNewServerChannelSinkStack =
      gcnew MyServerChannelSinkStack;
   myNewServerChannelSinkStack->MyCreateSinkMethod();
   myNewServerChannelSinkStack->MyGetChannelDataMethod();
}
