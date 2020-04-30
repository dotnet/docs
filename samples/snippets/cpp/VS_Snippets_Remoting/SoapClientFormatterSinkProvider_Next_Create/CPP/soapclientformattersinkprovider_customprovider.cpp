
// System.Runtime.Remoting.Channels.SoapServerFormatterSinkProvider.CreateSink
using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;

public ref class MyKey{};

private ref class MyClientChannelSink: public BaseChannelObjectWithProperties, public IClientChannelSink
{
private:
   IClientChannelSink^ nextClientSink;

public:
   MyClientChannelSink()
      : nextClientSink( nullptr )
   {}

   MyClientChannelSink( IClientChannelSink^ nextSink )
      : BaseChannelObjectWithProperties()
   {
      nextClientSink = nextSink;
   }

   MyClientChannelSink( IChannelSender^ /*channel*/, String^ /*url*/, Object^ /*remoteChannelData*/, IClientChannelSink^ nextSink )
      : BaseChannelObjectWithProperties()
   {
      nextClientSink = nextSink;
   }

   virtual void ProcessMessage( IMessage^ msg, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream )
   {
      nextClientSink->ProcessMessage( msg, requestHeaders, requestStream, responseHeaders, responseStream );
   }

   virtual void AsyncProcessRequest( IClientChannelSinkStack^ sinkStack, IMessage^ msg, ITransportHeaders^ headers, Stream^ stream )
   {
      sinkStack->Push( this, nullptr );
      nextClientSink->AsyncProcessRequest( sinkStack, msg, headers, stream );
   }

   virtual void AsyncProcessResponse( IClientResponseChannelSinkStack^ sinkStack, Object^ /*state*/, ITransportHeaders^ headers, Stream^ stream )
   {
      sinkStack->AsyncProcessResponse( headers, stream );
   }

   virtual Stream^ GetRequestStream( IMessage^ /*msg*/, ITransportHeaders^ /*headers*/ )
   {
      return nullptr;
   }


   property IClientChannelSink^ NextChannelSink 
   {
      virtual IClientChannelSink^ get()
      {
         return nextClientSink;
      }

   }

   property Object^ Item [Object^]
   {
      virtual Object^ get( Object^ key ) override
      {
         if ( key == MyKey::typeid )
                  return this;

         return nullptr;
      }

      virtual void set( Object^ /*value*/, Object^ /*key*/ ) override
      {
         throw gcnew NotSupportedException;
      }

   }

   property ICollection^ Keys 
   {
      virtual ICollection^ get() override
      {
         ArrayList^ myKeys = gcnew ArrayList( 1 );
         myKeys->Add( MyKey::typeid );
         return myKeys;
      }
   }
};

[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class MyClientProvider: public IClientChannelSinkProvider
{
private:
   IClientChannelSinkProvider^ nextProvider;

public:
   MyClientProvider()
      : nextProvider( nullptr )
   {}

   MyClientProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}

   virtual IClientChannelSink^ CreateSink( IChannelSender^ channel, String^ myUrl, Object^ remoteChannelData )
   {
      IClientChannelSink^ nextSink = nullptr;
      if ( nextProvider != nullptr )
      {
         nextSink = nextProvider->CreateSink( channel, myUrl, remoteChannelData );
         if ( nextSink == nullptr )
                  return nullptr;
      }

      return gcnew MyClientChannelSink( nextSink );
   }

   property IClientChannelSinkProvider^ Next 
   {
      virtual IClientChannelSinkProvider^ get()
      {
         return nextProvider;
      }

      virtual void set( IClientChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }
};

private ref class MyServerChannelSink: public BaseChannelObjectWithProperties, public IServerChannelSink
{
private:
   IServerChannelSink^ nextServerSink;

public:
   MyServerChannelSink()
      : nextServerSink( nullptr )
   {}

   MyServerChannelSink( IServerChannelSink^ nextSink )
      : BaseChannelObjectWithProperties()
   {
      nextServerSink = nextSink;
   }

   MyServerChannelSink( IChannelReceiver^ /*channel*/, IServerChannelSink^ nextSink )
      : BaseChannelObjectWithProperties()
   {
      nextServerSink = nextSink;
   }

   virtual ServerProcessing ProcessMessage( IServerChannelSinkStack^ sinkStack, IMessage^ requestMsg, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]IMessage^% msg, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream )
   {
      sinkStack->Push( this, nullptr );
      ServerProcessing processing = nextServerSink->ProcessMessage( sinkStack, requestMsg, requestHeaders, requestStream, msg, responseHeaders, responseStream );
      switch ( processing )
      {
         case ServerProcessing::Complete:
            sinkStack->Pop( this );
            break;

         case ServerProcessing::OneWay:
            sinkStack->Pop( this );
            break;

         case ServerProcessing::Async:
            sinkStack->Store( this, nullptr );
            break;
      }
      return processing;
   }

   virtual void AsyncProcessResponse( IServerResponseChannelSinkStack^ sinkStack, Object^ /*state*/, IMessage^ msg, ITransportHeaders^ headers, Stream^ stream )
   {
      sinkStack->AsyncProcessResponse( msg, headers, stream );
   }

   virtual Stream^ GetResponseStream( IServerResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, IMessage^ /*msg*/, ITransportHeaders^ /*headers*/ )
   {
      return nullptr;
   }

   property IServerChannelSink^ NextChannelSink 
   {
      virtual IServerChannelSink^ get()
      {
         return nextServerSink;
      }

   }

   property Object^ Item [Object^]
   {
      virtual Object^ get( Object^ key ) override
      {
         if ( key == MyKey::typeid )
                  return this;

         return nullptr;
      }

      virtual void set( Object^ /*value*/, Object^ /*key*/ ) override
      {
         throw gcnew NotSupportedException;
      }

   }

   property ICollection^ Keys 
   {
      virtual ICollection^ get() override
      {
         ArrayList^ myKeys = gcnew ArrayList( 1 );
         myKeys->Add( MyKey::typeid );
         return myKeys;
      }
   }
};

[System::Security::Permissions::PermissionSet(System::Security::
   Permissions::SecurityAction::Demand, Name = "FullTrust")]
public ref class MyServerProvider: public IServerChannelSinkProvider
{
private:
   IServerChannelSinkProvider^ nextProvider;

public:
   MyServerProvider()
      : nextProvider( nullptr )
   {}

   MyServerProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}

   virtual void GetChannelData( IChannelDataStore^ /*channelData*/ ){}

   virtual IServerChannelSink^ CreateSink( IChannelReceiver^ channel )
   {
      // <Snippet3>
      IServerChannelSink^ nextSink = nullptr;
      if ( nextProvider != nullptr )
      {
         Console::WriteLine( "The next server provider is:{0}", nextProvider );

         // Create a sink chain calling the 'SaopServerFormatterProvider'
         // 'CreateSink' method.
         nextSink = nextProvider->CreateSink( channel );
      }

      return gcnew MyServerChannelSink( nextSink );
      // </Snippet3>
   }


   property IServerChannelSinkProvider^ Next 
   {
      virtual IServerChannelSinkProvider^ get()
      {
         return nextProvider;
      }

      virtual void set( IServerChannelSinkProvider^ value )
      {
         nextProvider = value;
      }
   }
};
