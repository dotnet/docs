[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
internal class MyClientFormatterChannelSink :
         BaseChannelSinkWithProperties, IClientChannelSink, IMessageSink
{
   private IClientChannelSink nextClientSink=null;
   private IMessageSink nextMessageSink = null;

   public MyClientFormatterChannelSink(IClientChannelSink nextSink,
                                       IMessageSink nextMsgSink) : base()
   {
      nextClientSink = nextSink;
      nextMessageSink = nextMsgSink;
   }

   public void ProcessMessage(IMessage msg,
         ITransportHeaders requestHeaders, Stream requestStream,
         out ITransportHeaders responseHeaders, out Stream responseStream)
   {
      nextClientSink.ProcessMessage(msg, requestHeaders, requestStream,
               out responseHeaders, out responseStream);
   }

   public void AsyncProcessRequest(IClientChannelSinkStack sinkStack,
                  IMessage msg, ITransportHeaders headers, Stream myStream)
   {
      sinkStack.Push(this, null);
      nextClientSink.AsyncProcessRequest(sinkStack,msg,headers,myStream);
   }

   public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack,
         Object state, ITransportHeaders headers, Stream myStream)
   {
      sinkStack.AsyncProcessResponse(headers, myStream);
   }

   public Stream GetRequestStream(IMessage msg,ITransportHeaders headers)
   {
      return null;
   }

   public IClientChannelSink NextChannelSink
   {
      get
      {
         return nextClientSink;
      }
   }

   public IMessageSink NextSink
   {
      get
      {
         return nextMessageSink;
      }
   }

   public IMessageCtrl AsyncProcessMessage(IMessage msg,
                                                IMessageSink replySink)
   {
      return null;
   }

   public IMessage SyncProcessMessage(IMessage msg)
   {
      return nextMessageSink.SyncProcessMessage(msg);
   }

   public override Object this[Object key]
   {
      get
      {
         if (key == typeof(MyKey))
            return this;
         return null;
      }
      set
      {
         throw new NotSupportedException();
      }
   }
   public override ICollection Keys
   {
      get
      {
         ArrayList myKeys = new ArrayList(1);
         myKeys.Add(typeof(MyKey));
         return myKeys;
      }
   }
}
public class MyKey
{
}