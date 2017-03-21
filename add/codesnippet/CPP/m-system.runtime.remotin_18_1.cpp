   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   private ref class LoggingServerChannelSink: public BaseChannelObjectWithProperties, public IServerChannelSink
   {
   private:
      IServerChannelSink^ nextSink2;
      bool bEnabled2;

   public:
      LoggingServerChannelSink()
         : nextSink2( nullptr ), bEnabled2( true )
      {}

      LoggingServerChannelSink( IServerChannelSink^ localNextSink )
         : BaseChannelObjectWithProperties()
      {
         nextSink2 = localNextSink;
      }

      virtual ServerProcessing ProcessMessage( IServerChannelSinkStack^ sinkStack, IMessage^ requestMsg, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]IMessage^% responseMsg, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream ) = IServerChannelSink::ProcessMessage
      {
         if ( bEnabled2 )
         {
            Console::WriteLine( "----------Request Headers-----------" );
            
            Console::WriteLine( "{0}:{1}", CommonTransportKeys::IPAddress,
               requestHeaders[ CommonTransportKeys::IPAddress ] );
            Console::WriteLine( "{0}:{1}", CommonTransportKeys::ConnectionId,
               requestHeaders[ CommonTransportKeys::ConnectionId ] );
            Console::WriteLine( "{0}:{1}", CommonTransportKeys::RequestUri,
               requestHeaders[ CommonTransportKeys::RequestUri ] );
         }

         sinkStack->Push( this, nullptr );
         ServerProcessing processing = nextSink2->ProcessMessage( sinkStack, requestMsg, requestHeaders, requestStream, responseMsg, responseHeaders, responseStream );
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

      virtual void AsyncProcessResponse( IServerResponseChannelSinkStack^ sinkStack, Object^ /*state*/, IMessage^ msg, ITransportHeaders^ headers, Stream^ stream1 )
      {
         sinkStack->AsyncProcessResponse( msg, headers, stream1 );
      }

      virtual Stream^ GetResponseStream( IServerResponseChannelSinkStack^ /*sinkStack*/, Object^ /*state*/, IMessage^ /*msg*/, ITransportHeaders^ /*headers*/ )
      {
         return nullptr;
      }

      property IServerChannelSink^ NextChannelSink 
      {
         virtual IServerChannelSink^ get()
         {
            return nextSink2;
         }
      }
   };

   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   public ref class LoggingServerChannelSinkProvider: public IServerChannelSinkProvider
   {
   private:
      IServerChannelSinkProvider^ next2;

   public:
      LoggingServerChannelSinkProvider()
         : next2( nullptr )
      {}

      LoggingServerChannelSinkProvider( IDictionary^ /*properties*/, ICollection^ /*providerData*/ ){}

      virtual void GetChannelData( IChannelDataStore^ /*channelData*/ ){}

      virtual IServerChannelSink^ CreateSink( IChannelReceiver^ channel1 )
      {
         IServerChannelSink^ localNextSink = nullptr;
         if ( next2 != nullptr )
                  localNextSink = next2->CreateSink( channel1 );

         return gcnew LoggingServerChannelSink( localNextSink );
      }

      property IServerChannelSinkProvider^ Next 
      {
         virtual IServerChannelSinkProvider^ get()
         {
            return next2;
         }

         virtual void set( IServerChannelSinkProvider^ value )
         {
            next2 = value;
         }
      }
   };
}