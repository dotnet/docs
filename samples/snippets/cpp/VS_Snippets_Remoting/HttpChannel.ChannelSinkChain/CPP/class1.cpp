

#using <system.runtime.remoting.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Runtime::Remoting;
using namespace System::Runtime::Remoting::Channels;
using namespace System::IO;
using namespace System::Runtime::Remoting::Messaging;

// This snippet demonstrates HttpChannel::ChannelSinkChain.
// client code should NOT call this call directly. So, I'm
// writing a class that implements the member as HttpChannel
// does. That is, it returns the first sink after the transport
// sink. ie... if the sink chain is transport=>encryption=>formatter
// then this member should return encryption.

// <Snippet1>
ref class CustomChannel: public BaseChannelWithProperties, public IChannelReceiverHook, public IChannelReceiver, public IChannel, public IChannelSender
{
public:

   property IServerChannelSink^ ChannelSinkChain 
   {
      // TransportSink is a private class defined within CustomChannel.
      virtual IServerChannelSink^ get()
      {
         return transportSink->NextChannelSink;
      }
   }

   // Rest of CustomChannel's implementation...
   //</Snippet1>
   CustomChannel()
   {
      BinaryServerFormatterSink^ formatterSink = gcnew BinaryServerFormatterSink( BinaryServerFormatterSink::Protocol::Http,nullptr,this );
      transportSink = gcnew TransportSink( formatterSink );
      priority = 0;
      dataStore = gcnew ChannelDataStore( nullptr );
      wantsToListen = true;
      socket = "";
   }

   CustomChannel( int portNum )
   {
      BinaryServerFormatterSink^ formatterSink = gcnew BinaryServerFormatterSink( BinaryServerFormatterSink::Protocol::Http,nullptr,this );
      transportSink = gcnew TransportSink( formatterSink );
      priority = 0;
      dataStore = gcnew ChannelDataStore( nullptr );
      wantsToListen = false;
      socket = "http://localhost: {0}",portNum;
   }

   CustomChannel( IDictionary^ properties, IClientChannelSinkProvider^ clientSinkProvider, IServerChannelSinkProvider^ serverSinkProvider ){}

   property String^ ChannelName 
   {
      virtual String^ get()
      {
         return "custom";
      }

   }

   property Object^ ChannelData 
   {
      virtual Object^ get()
      {
         return dataStore;
      }

   }
   virtual void AddHookChannelUri( String^ channelUri )
   {
      if ( channelUri != nullptr )
      {
         array<String^>^uris = dataStore->ChannelUris;
         if ( uris == nullptr )
         {
            array<String^>^newUris = gcnew array<String^>(1);
            newUris[ 0 ] = channelUri;
            dataStore->ChannelUris = newUris;
         }
         else
         {
            String^ msg = "This channel is already listening for data, and can't be hooked into at this stage.";
            throw gcnew System::Runtime::Remoting::RemotingException( msg );
         }
      }
   }

   property bool WantsToListen 
   {
      virtual bool get()
      {
         return wantsToListen;
      }

   }

   property int ChannelPriority 
   {
      virtual int get()
      {
         return priority;
      }

   }

   property String^ ChannelScheme 
   {
      virtual String^ get()
      {
         return "http";
      }

   }
   virtual array<String^>^ GetUrlsForUri( String^ uri )
   {
      array<String^>^urls = gcnew array<String^>(dataStore->ChannelUris->Length);
      int i = 0;
      IEnumerator^ myEnum = dataStore->ChannelUris->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         String^ currUri = safe_cast<String^>(myEnum->Current);
         urls[ i ] = String::Format(  "{0}/{1}", socket, currUri );
         i++;
      }

      return urls;
   }

   virtual void StartListening( Object^ data ){}

   virtual void StopListening( Object^ data ){}

   virtual String^ Parse( String^ url, String^% objectURI )
   {
      int lastSlash = url->LastIndexOf( "/" );
       objectURI = "";
       objectURI = url->Substring( lastSlash );
      return socket;
   }

   virtual IMessageSink^ CreateMessageSink( String^ url, Object^ remoteChannelData, String^% objectURI )
   {
      Parse( url, objectURI );
      return nullptr;
   }

   ref class TransportSink: public IServerChannelSink
   {
   public:

      property IServerChannelSink^ NextChannelSink 
      {
         virtual IServerChannelSink^ get()
         {
            return next;
         }

      }
      TransportSink( IServerChannelSink^ nextSink )
      {
         next = nextSink;
      }

      // I am not implementing these because they are
      // not needed for my snippet but they must be here.
      virtual void AsyncProcessResponse( IServerResponseChannelSinkStack^ sinkStack, Object^ state, IMessage^ msg, ITransportHeaders^ headers, Stream^ stream ){}

      virtual Stream^ GetResponseStream( IServerResponseChannelSinkStack^ sinkStack, Object^ state, IMessage^ msg, ITransportHeaders^ headers )
      {
         return nullptr;
      }

      virtual ServerProcessing ProcessMessage( IServerChannelSinkStack^ sinkStack, IMessage^ requestMsg, ITransportHeaders^ requestHeaders, Stream^ requestStream, IMessage^% msg, ITransportHeaders^% responseHeaders, Stream^% responseStream )
      {
         msg = nullptr;
         responseHeaders = nullptr;
         responseStream = nullptr;
         return ServerProcessing::Complete;
      }

      property IDictionary^ Properties 
      {
         virtual IDictionary^ get()
         {
            return nullptr;
         }
      }

   private:
      IServerChannelSink^ next;
   };

private:
   ChannelDataStore^ dataStore;
   bool wantsToListen;
   int priority;
   String^ socket;
   TransportSink^ transportSink;
};

int main()
{
   CustomChannel^ channel = gcnew CustomChannel( 8085 );
   channel->AddHookChannelUri( "TempConverter" );

   //System::Runtime::Remoting::Channels.Http::HttpChannel* channel = new System::Runtime::Remoting::Channels.Http::HttpChannel(8085);
   //System::Runtime::Remoting::Channels.Tcp::TcpChannel* channel = new System::Runtime::Remoting::Channels.Tcp::TcpChannel(8085);
   System::Console::WriteLine( channel->ChannelSinkChain );
   return 0;
}
