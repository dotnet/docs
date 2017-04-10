using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.IO;
using System.Runtime.Remoting.Messaging;

// This snippet demonstrates HttpChannel.ChannelSinkChain.
// client code should NOT call this call directly. So, I'm
// writing a class that implements the member as HttpChannel
// does. That is, it returns the first sink after the transport
// sink. ie... if the sink chain is transport=>encryption=>formatter
// then this member should return encryption.

// <Snippet1>
class CustomChannel : BaseChannelWithProperties, IChannelReceiverHook,
   IChannelReceiver, IChannel, IChannelSender {

   // TransportSink is a private class defined within CustomChannel.
   TransportSink transportSink;

   public IServerChannelSink ChannelSinkChain {
      get { return transportSink.NextChannelSink; }
   }

   // Rest of CustomChannel's implementation...
   //</Snippet1>

   public static void Main() {
      CustomChannel channel = new CustomChannel(8085);
      channel.AddHookChannelUri("TempConverter");

      /*System.Runtime.Remoting.Channels.Http.HttpChannel channel = 
         new System.Runtime.Remoting.Channels.Http.HttpChannel(8085);*/

      /*System.Runtime.Remoting.Channels.Tcp.TcpChannel channel =
         new System.Runtime.Remoting.Channels.Tcp.TcpChannel(8085);*/

      System.Console.WriteLine(channel.ChannelSinkChain);
   }

   private ChannelDataStore dataStore;
   private bool wantsToListen;
   private int priority;
   private string socket;

   public CustomChannel() {
      BinaryServerFormatterSink formatterSink =
         new BinaryServerFormatterSink(
         BinaryServerFormatterSink.Protocol.Http,
         null,
         this);
      transportSink = new TransportSink(formatterSink);
      priority = 0;
      dataStore = new ChannelDataStore(null);
      wantsToListen = true;
      socket = "";
   }

   public CustomChannel(int portNum) {
      BinaryServerFormatterSink formatterSink =
         new BinaryServerFormatterSink(
         BinaryServerFormatterSink.Protocol.Http,
         null,
         this);
      transportSink = new TransportSink(formatterSink);
      priority = 0;
      dataStore = new ChannelDataStore(null);
      wantsToListen = false;
      socket = "http://localhost:" + portNum.ToString();
   }

   public CustomChannel(
      IDictionary properties,
      IClientChannelSinkProvider clientSinkProvider,
      IServerChannelSinkProvider serverSinkProvider) {
         
   
   }

   public string ChannelName {
      get {
         return "custom";
      }
   }

   public object ChannelData {
      get {
         return (object) dataStore;
      }
   }

   public void AddHookChannelUri(string channelUri) {

      if (channelUri != null) {
         string [] uris = dataStore.ChannelUris;

         if (uris == null) {
            string [] newUris = new string[1];
            newUris[0] = channelUri;
            dataStore.ChannelUris = newUris;
         } else {
            string msg = "This channel is already listening for data, " +
               "and can't be hooked into at this stage.";
            throw new System.Runtime.Remoting.RemotingException(msg);
         }
      }
   }

   public bool WantsToListen {
      get { return wantsToListen; }
   }

   public int ChannelPriority {
      get { return priority; }
   }

   public string ChannelScheme {
      get { return "http"; }
   }

   public string[] GetUrlsForUri(string uri) {
      string[] urls = new string[dataStore.ChannelUris.Length];
      int i = 0;
      foreach (string currUri in dataStore.ChannelUris) {
         urls[i] = socket + "/" + currUri;
         i++;
      }
      return urls;
   }

   public void StartListening(object data){
   
   }

   public void StopListening(object data){
      
   }

   public string Parse(string url, out string objectURI) {
      int lastSlash = url.LastIndexOf("/");
      objectURI = "";
      objectURI = url.Substring(lastSlash);
      return socket;
   }

   public IMessageSink CreateMessageSink(string url,
      object remoteChannelData,
      out string objectURI) {
      Parse(url, out objectURI);
      
      return null;
   }

   
   private class TransportSink: IServerChannelSink {
      private IServerChannelSink next;

      public IServerChannelSink NextChannelSink {
         get { return next; }
      }

      public TransportSink(IServerChannelSink nextSink) {
         next = nextSink;
      }

      // I am not implementing these because they are
      // not needed for my snippet but they must be here.
      public void AsyncProcessResponse(
         IServerResponseChannelSinkStack sinkStack,
         object state,
         IMessage msg,
         ITransportHeaders headers,
         Stream stream
         ) {
         
      }

      public Stream GetResponseStream(
         IServerResponseChannelSinkStack sinkStack,
         object state,
         IMessage msg,
         ITransportHeaders headers
         ) {
         return null;
      }

      public ServerProcessing ProcessMessage(
         IServerChannelSinkStack sinkStack,
         IMessage requestMsg,
         ITransportHeaders requestHeaders,
         Stream requestStream,
         out IMessage msg,
         out ITransportHeaders responseHeaders,
         out Stream responseStream
         ) {   

         msg = null;
         responseHeaders = null;
         responseStream = null;
         return ServerProcessing.Complete;
      }

      public IDictionary Properties {
         get {
            return null;      
         }
      } 
   }
}
