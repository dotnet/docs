
// <snippet20>
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
   // <snippet21>
   // The next sink in the chain.
   IClientChannelSink^ nextSink;
   // </snippet21>


   // <snippet22>
public:
   property IClientChannelSink^ NextChannelSink 
   {
      virtual IClientChannelSink^ get()
      {
         return (nextSink);
      }
   }
   // </snippet22>

   // <snippet23>
   virtual Stream^ GetRequestStream( IMessage^ message, ITransportHeaders^ requestHeaders )
   {
      // Get the request stream from the next sink in the chain.
      return (nextSink->GetRequestStream( message, requestHeaders ));
   }
   // </snippet23>

   // <snippet24>
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
   // </snippet24>

   // <snippet25>
   // For synchronous remoting, it is not necessary to implement this method.
   virtual void AsyncProcessRequest( IClientChannelSinkStack^ /*sinkStack*/, IMessage^ /*message*/, ITransportHeaders^ /*requestHeaders*/, Stream^ /*requestStream*/ )
   {
      throw gcnew NotImplementedException;
   }
   // </snippet25>

   // <snippet26>
   virtual void AsyncProcessResponse( IClientResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, ITransportHeaders^ /*responseHeaders*/, Stream^ /*responseStream*/ )
   {
      throw gcnew NotImplementedException;
   }

   // </snippet26>
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
// </snippet20>

// <snippet30>
[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class ClientSinkProvider: public IClientChannelSinkProvider
{
private:

   // <snippet31>
   // The next provider in the chain.
   IClientChannelSinkProvider^ nextProvider;
   // </snippet31>

   // <snippet32>
public:
   property IClientChannelSinkProvider^ Next 
   {
      virtual IClientChannelSinkProvider^ get()
      {
         return (nextProvider);
      }

      virtual void set( IClientChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }
   // </snippet32>

   // <snippet33>
   virtual IClientChannelSink^ CreateSink( IChannelSender^ channel, String^ url, Object^ remoteChannelData )
   {
      Console::WriteLine( "Creating ClientSink for {0}", url );
      
      // Create the next sink in the chain.
      IClientChannelSink^ nextSink = nextProvider->CreateSink( channel, url, remoteChannelData );
      
      // Hook our sink up to it.
      return (gcnew ClientSink( nextSink ));
   }
   // </snippet33>

   // This constructor is required in order to use the provider in file-based configuration.
   // It need not do anything unless you want to use the information in the parameters.
   ClientSinkProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}
};
// </snippet30>
