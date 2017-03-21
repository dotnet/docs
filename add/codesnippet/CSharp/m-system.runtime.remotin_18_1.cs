   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class LoggingServerChannelSinkProvider : IServerChannelSinkProvider
   {
      private IServerChannelSinkProvider next2 = null;
      public LoggingServerChannelSinkProvider(IDictionary properties, ICollection providerData)
      {
      }
      public void GetChannelData(IChannelDataStore channelData)
      {
      }
      public IServerChannelSink CreateSink(IChannelReceiver channel1)
      {
         IServerChannelSink localNextSink = null;
         if (next2 != null)
            localNextSink = next2.CreateSink(channel1);
         return new LoggingServerChannelSink(localNextSink);
      }
      public IServerChannelSinkProvider Next
      {
         get
         {
            return next2;
         }
         set
         {
            next2 = value;
         }
      }
   }
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   internal class LoggingServerChannelSink : BaseChannelObjectWithProperties, IServerChannelSink
   {
      private IServerChannelSink nextSink2 = null;
      private bool bEnabled2 = true;
      public LoggingServerChannelSink(IServerChannelSink localNextSink) : base()
      {
         nextSink2 = localNextSink;
      }
      public ServerProcessing ProcessMessage(   IServerChannelSinkStack sinkStack,
   IMessage requestMsg,
   ITransportHeaders requestHeaders,
   Stream requestStream,
   out IMessage responseMsg,
   out ITransportHeaders responseHeaders,
   out Stream responseStream
)
      {
         if (bEnabled2)
         {
            Console.WriteLine("----------Request Headers-----------");
            Console.WriteLine( CommonTransportKeys.IPAddress + ":" +
               requestHeaders[CommonTransportKeys.IPAddress]);
            Console.WriteLine( CommonTransportKeys.ConnectionId + ":" +
               requestHeaders[CommonTransportKeys.ConnectionId]);
            Console.WriteLine( CommonTransportKeys.RequestUri + ":" +
               requestHeaders[CommonTransportKeys.RequestUri]);

         }
         sinkStack.Push(this, null);
         ServerProcessing processing =
            nextSink2.ProcessMessage(sinkStack, requestMsg, requestHeaders, requestStream, out responseMsg,
            out responseHeaders, out responseStream);

         switch (processing)
         {
            case ServerProcessing.Complete :
            {
               sinkStack.Pop(this);
               break;
            }
            case ServerProcessing.OneWay:
            {
               sinkStack.Pop(this);
               break;
            }
            case ServerProcessing.Async:
            {
               sinkStack.Store(this, null);
               break;
            }
         }
         return processing;
      }
      public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, Object state,
         IMessage msg, ITransportHeaders headers, Stream stream1)
      {
         sinkStack.AsyncProcessResponse(msg, headers, stream1);
      }
      public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, Object state,
         IMessage msg, ITransportHeaders headers)
      {
         return null;
      }
      public IServerChannelSink NextChannelSink
      {
         get
         {
            return nextSink2;
         }
      }
   }