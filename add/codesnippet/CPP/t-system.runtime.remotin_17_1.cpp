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
   // The next sink in the chain.
   IServerChannelSink^ nextSink;

public:
   property IServerChannelSink^ NextChannelSink 
   {
      virtual IServerChannelSink^ get()
      {
         return (nextSink);
      }
   }

   virtual Stream^ GetResponseStream( IServerResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, IMessage^ /*message*/, ITransportHeaders^ /*responseHeaders*/ )
   {
      return nullptr;
   }

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

   virtual void AsyncProcessResponse( IServerResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, IMessage^ /*message*/, ITransportHeaders^ /*responseHeaders*/, Stream^ /*responseStream*/ )
   {
      throw gcnew NotImplementedException;
   }

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