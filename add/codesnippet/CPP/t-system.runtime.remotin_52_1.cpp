using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;

[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class ClientSink: public BaseChannelSinkWithProperties, public IClientChannelSink
{
private:

   // This class inherits from BaseChannelSinkWithPropertes
   // to get an implementation of IChannelSinkBase.
   // The next sink in the chain.
   IClientChannelSink^ nextSink;


public:
   property IClientChannelSink^ NextChannelSink 
   {
      virtual IClientChannelSink^ get()
      {
         return (nextSink);
      }
   }

   virtual Stream^ GetRequestStream( IMessage^ message, ITransportHeaders^ requestHeaders )
   {
      // Get the request stream from the next sink in the chain.
      return (nextSink->GetRequestStream( message, requestHeaders ));
   }

   virtual void ProcessMessage( IMessage^ message, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream )
   {
      // Print the request message properties.
      Console::WriteLine( "---- Message from the client ----" );
      IDictionary^ dictionary = message->Properties;
      IEnumerator^ myEnum = dictionary->Keys->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Object^ key = safe_cast<Object^>(myEnum->Current);
         Console::WriteLine( "{0} = {1}", key, dictionary[ key ] );
      }

      Console::WriteLine( "---------------------------------" );

      // Hand off to the next sink in the chain.
      nextSink->ProcessMessage( message, requestHeaders, requestStream, responseHeaders, responseStream );
   }

   // For synchronous remoting, it is not necessary to implement this method.
   virtual void AsyncProcessRequest( IClientChannelSinkStack^ /*sinkStack*/, IMessage^ /*message*/, ITransportHeaders^ /*requestHeaders*/, Stream^ /*requestStream*/ )
   {
      throw gcnew NotImplementedException;
   }

   virtual void AsyncProcessResponse( IClientResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, ITransportHeaders^ /*responseHeaders*/, Stream^ /*responseStream*/ )
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
   ClientSink( IClientChannelSink^ sink )
   {
      if ( sink == nullptr )
            throw gcnew ArgumentNullException( "sink" );

      nextSink = sink;
   }
};