[SecurityPermission(SecurityAction::Demand, Flags = SecurityPermissionFlag::Infrastructure)]
private ref class MyClientFormatterChannelSink: public BaseChannelSinkWithProperties, public IClientChannelSink, public IMessageSink
{
private:
   IClientChannelSink^ nextClientSink;
   IMessageSink^ nextMessageSink;

public:
   MyClientFormatterChannelSink()
      : nextClientSink( nullptr ), nextMessageSink( nullptr )
   {}

   MyClientFormatterChannelSink( IClientChannelSink^ nextSink, IMessageSink^ nextMsgSink )
      : BaseChannelSinkWithProperties()
   {
      nextClientSink = nextSink;
      nextMessageSink = nextMsgSink;
   }

	virtual void ProcessMessage( IMessage^ message, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream )
	{
      nextClientSink->ProcessMessage( message, requestHeaders, requestStream, responseHeaders, responseStream );
	}



   virtual void AsyncProcessRequest( IClientChannelSinkStack^ sinkStack, IMessage^ msg, ITransportHeaders^ headers, Stream^ myStream )
   {
      sinkStack->Push( this, nullptr );
      nextClientSink->AsyncProcessRequest( sinkStack, msg, headers, myStream );
   }

   virtual void AsyncProcessResponse( IClientResponseChannelSinkStack^ sinkStack, Object^ /*state*/, ITransportHeaders^ headers, Stream^ myStream )
   {
      sinkStack->AsyncProcessResponse( headers, myStream );
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

   property IMessageSink^ NextSink 
   {
      virtual IMessageSink^ get()
      {
         return nextMessageSink;
      }

   }

   virtual IMessageCtrl^ AsyncProcessMessage( IMessage^ /*msg*/, IMessageSink^ /*replySink*/ )
   {
      return nullptr;
   }

   virtual IMessage^ SyncProcessMessage( IMessage^ msg )
   {
      return nextMessageSink->SyncProcessMessage( msg );
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


