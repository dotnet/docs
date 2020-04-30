
// System.Runtime.Remoting.Channels.SoapClientFormatterSinkProvider.CreateSink
// System.Runtime.Remoting.Channels.BaseChannelSinkWithProperties
/*
The following example demonstrates the 'BaseChannelSinkWithProperties'
class and 'CreateSink' method of 'SoapClientFormatterSinkProvider' class.
Custom client formatter provider is defined by implementing
the 'IClientChannelSinkProvider' interface and custom channel sink is
defined by inheriting 'BaseChannelSinkWithProperties' abstract class.
The sink provider chain has the custom sink provider and 
'SoapClientFormatterSinkProvider'. The 'CreateSink' method is used to 
return a sink to the caller and form the sink chain which is used to process
the message being passed through it.
*/
using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Permissions;

public ref class MyKey{};

// <Snippet2>
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



// </Snippet2>
[SecurityPermission(SecurityAction::Demand, Flags = SecurityPermissionFlag::Infrastructure)]
public ref class MyClientFormatterProvider: public IClientChannelSinkProvider
{
private:
   IClientChannelSinkProvider^ nextProvider;

public:
   MyClientFormatterProvider() : nextProvider( nullptr ) {}

   virtual IClientChannelSink^ CreateSink( IChannelSender^ channel, String^ myUrl, Object^ remoteChannelData )
   {  
      // <Snippet1>
      IClientChannelSink^ nextSink = nullptr;
      IMessageSink^ nextMsgSink = nullptr;
      if ( nextProvider != nullptr )
      {
         Console::WriteLine( "Next client sink provider is: {0}", nextProvider );
         
         // Create a sink chain calling the next sink provider's
         // 'CreateSink' method.
         nextSink = nextProvider->CreateSink( channel, myUrl, remoteChannelData );
         nextMsgSink = dynamic_cast<IMessageSink^>(nextSink);
      }
      // </Snippet1>
      return gcnew MyClientFormatterChannelSink( nextSink,nextMsgSink );
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



