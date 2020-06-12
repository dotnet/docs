// System.Runtime.Remoting.Channels.CommonTransportKeys
// System.Runtime.Remoting.Channels.CommonTransportKeys.IPAddress
// System.Runtime.Remoting.Channels.CommonTransportKeys.ConnectionId
// System.Runtime.Remoting.Channels.CommonTransportKeys.RequestUri
/* 
This program demonstrates 'CommonTransportKeys' class and the static members 'IPAddress', 'ConnectionId',
'RequestUri'. 'LoggingClientChannelSinkProvider' and 'LoggingServerChannelSinkProvider' classes are
created which inherits'IClientChannelSinkProvider' and 'IServerChannelSinkProvider' respectively.
'ProcessMessage' method is having 'ITransportHeaders' parameter which gives the required header values.

Note: This snippet assumes CommonTransportKeys_Server.cs, CommonTransportKeys_Client.cs,
CommonTransportKeys_Share.cs files along with channels.config, server.exe.config, client.exe.
config config files.
*/
#using <System.Runtime.Remoting.dll>

using namespace System::Runtime::InteropServices;
using namespace System;
using namespace System::Collections;
using namespace System::IO;
using namespace System::Runtime::Remoting::Channels;
using namespace System::Runtime::Remoting::Messaging;
using namespace System::Security::Permissions;

namespace Logging
{
   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   private ref class LoggingClientChannelSink: public BaseChannelObjectWithProperties, public IClientChannelSink
   {
   private:
      IClientChannelSink^ nextSink1;

   public:
      LoggingClientChannelSink()
         : nextSink1( nullptr )
      {}

      LoggingClientChannelSink( IClientChannelSink^ localNextSink )
         : BaseChannelObjectWithProperties()
      {
         nextSink1 = localNextSink;
      }


      virtual void ProcessMessage( IMessage^ msg, ITransportHeaders^ requestHeaders, Stream^ requestStream, [Out]ITransportHeaders^% responseHeaders, [Out]Stream^% responseStream ) = IClientChannelSink::ProcessMessage
      {
         nextSink1->ProcessMessage( msg, requestHeaders, requestStream, responseHeaders, responseStream );
      }

      virtual void AsyncProcessRequest( IClientChannelSinkStack^ sinkStack, IMessage^ msg, ITransportHeaders^ headers, Stream^ stream1 )
      {
         sinkStack->Push( this, nullptr );
         nextSink1->AsyncProcessRequest( sinkStack, msg, headers, stream1 );
      }

      virtual void AsyncProcessResponse( IClientResponseChannelSinkStack^ sinkStack, Object^ /*state*/, ITransportHeaders^ headers, Stream^ stream1 )
      {
         sinkStack->AsyncProcessResponse( headers, stream1 );
      }

      virtual Stream^ GetRequestStream( IMessage^ /*msg*/, ITransportHeaders^ /*headers*/ )
      {
         return nullptr;
      }

      property IClientChannelSink^ NextChannelSink 
      {
         virtual IClientChannelSink^ get()
         {
            return nextSink1;
         }
      }
   };

   [PermissionSet(SecurityAction::Demand, Name="FullTrust")]
   public ref class LoggingClientChannelSinkProvider: public IClientChannelSinkProvider
   {
   private:
      IClientChannelSinkProvider^ next1;

   public:
      LoggingClientChannelSinkProvider()
         : next1( nullptr )
      {}

      virtual IClientChannelSink^ CreateSink( IChannelSender^ channel1, String^ url1, Object^ remoteChannelData )
      {
         IClientChannelSink^ localNextSink = nullptr;
         if ( next1 != nullptr )
         {
            localNextSink = next1->CreateSink( channel1, url1, remoteChannelData );
            if ( localNextSink == nullptr )
                        return nullptr;
         }

         return gcnew LoggingClientChannelSink( localNextSink );
      }

      property IClientChannelSinkProvider^ Next 
      {
         virtual IClientChannelSinkProvider^ get()
         {
            return next1;
         }

         virtual void set( IClientChannelSinkProvider^ value )
         {
            next1 = value;
         }
      }
   };

   // <Snippet1>
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
            
            // <Snippet2>
            Console::WriteLine( "{0}:{1}", CommonTransportKeys::IPAddress,
               requestHeaders[ CommonTransportKeys::IPAddress ] );
            // </Snippet2>
            // <Snippet3>
            Console::WriteLine( "{0}:{1}", CommonTransportKeys::ConnectionId,
               requestHeaders[ CommonTransportKeys::ConnectionId ] );
            // </Snippet3>
            // <Snippet4>
            Console::WriteLine( "{0}:{1}", CommonTransportKeys::RequestUri,
               requestHeaders[ CommonTransportKeys::RequestUri ] );
            // </Snippet4>
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
// </Snippet1>
