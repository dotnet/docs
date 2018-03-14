
// <snippet60>
using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;

[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class ServerSink: public BaseChannelSinkWithProperties, public IServerChannelSink
{
private:

   // This class inherits from BaseChannelSinkWithPropertes
   // to get an implementation of IChannelSinkBase.
   // <snippet61>
   // The next sink in the chain.
   IServerChannelSink^ nextSink;
   // </snippet61>

   // <snippet62>
public:
   property IServerChannelSink^ NextChannelSink 
   {
      virtual IServerChannelSink^ get()
      {
         return (nextSink);
      }
   }
   // </snippet62>

   // <snippet63>
   virtual Stream^ GetResponseStream( IServerResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, IMessage^ /*message*/, ITransportHeaders^ /*responseHeaders*/ )
   {
      return nullptr;
   }
   // </snippet63>

   // <snippet64>
   virtual ServerProcessing ProcessMessage( IServerChannelSinkStack^ sinkStack, IMessage^ requestMessage, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]IMessage^% responseMessage, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream )
   {
      // Hand off to the next sink for processing.
      sinkStack->Push( this, nullptr );
      ServerProcessing status = nextSink->ProcessMessage( sinkStack, requestMessage, requestHeaders, requestStream, responseMessage, responseHeaders, responseStream );

      // Print the response message properties.
      Console::WriteLine( "---- Message from the server ----" );
      IDictionary^ dictionary = ( *responseMessage).Properties;
      IEnumerator^ myEnum = dictionary->Keys->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Object^ key = safe_cast<Object^>(myEnum->Current);
         Console::WriteLine( "{0} = {1}", key, dictionary[ key ] );
      }

      Console::WriteLine( "---------------------------------" );
      return (status);
   }
   // </snippet64>

   // <snippet65>
   virtual void AsyncProcessResponse( IServerResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, IMessage^ /*message*/, ITransportHeaders^ /*responseHeaders*/, Stream^ /*responseStream*/ )
   {
      throw gcnew NotImplementedException;
   }
   // </snippet65>

   property System::Collections::IDictionary^ Properties 
   {
      virtual System::Collections::IDictionary^ get() override
      {
         return (dynamic_cast<BaseChannelSinkWithProperties^>(this))->Properties;
      }
   }

   // Constructor
   ServerSink( IServerChannelSink^ sink )
   {
      if ( sink == nullptr )
            throw gcnew ArgumentNullException( "sink" );

      nextSink = sink;
   }
};
// </snippet60>

// <snippet70>
[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class ServerSinkProvider: public IServerChannelSinkProvider
{
   // <snippet71>
   // The next provider in the chain.
private:
   IServerChannelSinkProvider^ nextProvider;
   // </snippet71>

   // <snippet72>
public:
   property IServerChannelSinkProvider^ Next 
   {
      virtual IServerChannelSinkProvider^ get()
      {
         return (nextProvider);
      }

      virtual void set( IServerChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }
   // </snippet72>

   // <snippet73>
   virtual IServerChannelSink^ CreateSink( IChannelReceiver^ channel )
   {
      Console::WriteLine( "Creating ServerSink" );

      // Create the next sink in the chain.
      IServerChannelSink^ nextSink = nextProvider->CreateSink( channel );

      // Hook our sink up to it.
      return (gcnew ServerSink( nextSink ));
   }
   // </snippet73>

   // <snippet74>
   virtual void GetChannelData( IChannelDataStore^ /*channelData*/ ){}
   // </snippet74>

   // This constructor is required in order to use the provider in file-based configuration.
   // It need not do anything unless you want to use the information in the parameters.
   ServerSinkProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}
};
// </snippet70>
