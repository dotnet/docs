// System.Runtime.Remoting.Channels.SoapServerFormatterSinkProvider.CreateSink

using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class MyClientProvider : IClientChannelSinkProvider
{
   private IClientChannelSinkProvider nextProvider = null;
   public MyClientProvider()
   {
   }
   public MyClientProvider(IDictionary properties, ICollection providerData)
   {
   }
   public IClientChannelSink CreateSink(IChannelSender channel, String myUrl,
                                       Object remoteChannelData)
   {
      IClientChannelSink nextSink = null;
      if (nextProvider != null)
      {
            nextSink = nextProvider.CreateSink(channel, myUrl, remoteChannelData);
            if (nextSink == null)
               return null;
      }
      return new MyClientChannelSink(nextSink);
   }
   public IClientChannelSinkProvider Next
   {
      get
      {
         return nextProvider;
      }
      set
      {
         nextProvider = value;
      }
   }
}

[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
internal class MyClientChannelSink : BaseChannelObjectWithProperties, IClientChannelSink
{
   private IClientChannelSink nextClientSink = null;

   public MyClientChannelSink(IClientChannelSink nextSink) : base()
   {
      nextClientSink = nextSink;
   }
   public MyClientChannelSink(IChannelSender channel, String url, Object remoteChannelData,
                                    IClientChannelSink nextSink) : base()
   {
      nextClientSink = nextSink;
   }
   public void ProcessMessage(IMessage msg,
                              ITransportHeaders requestHeaders, Stream requestStream,
                              out ITransportHeaders responseHeaders, out Stream responseStream)
   {
      nextClientSink.ProcessMessage(msg, requestHeaders, requestStream,
                                 out responseHeaders, out responseStream);
   }
   public void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg,
                                    ITransportHeaders headers, Stream stream)
   {
      sinkStack.Push(this, null);
      nextClientSink.AsyncProcessRequest(sinkStack, msg, headers, stream);
   }

   public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, Object state,
                                    ITransportHeaders headers, Stream stream)
   {
         sinkStack.AsyncProcessResponse(headers, stream);
   }

   public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
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

[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
public class MyServerProvider : IServerChannelSinkProvider
{
   private IServerChannelSinkProvider nextProvider = null;

   public MyServerProvider()
   {
   }

   public MyServerProvider(IDictionary properties, ICollection providerData)
   {
   }

   public void GetChannelData(IChannelDataStore channelData)
   {
   }

   public IServerChannelSink CreateSink(IChannelReceiver channel)
   {
// <Snippet3>
      IServerChannelSink nextSink = null;
      if (nextProvider != null)
      {
            Console.WriteLine("The next server provider is:"
                                             +nextProvider);
         // Create a sink chain calling the 'SaopServerFormatterProvider'
         // 'CreateSink' method.
         nextSink = nextProvider.CreateSink(channel);
      }
      return new MyServerChannelSink(nextSink);
// </Snippet3>
   }
   public IServerChannelSinkProvider Next
   {
      get
      {
         return nextProvider;
      }
      set
      {
         nextProvider = value;
      }
   }
}

[PermissionSet(SecurityAction.Demand, Name="FullTrust")]
internal class MyServerChannelSink : BaseChannelObjectWithProperties, IServerChannelSink
{
   private IServerChannelSink nextServerSink = null;

   public MyServerChannelSink(IServerChannelSink nextSink) : base()
   {
      nextServerSink = nextSink;
   }

   public MyServerChannelSink(IChannelReceiver channel,
                                    IServerChannelSink nextSink) : base()
   {
      nextServerSink = nextSink;
   }

   public ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg,
                                          ITransportHeaders requestHeaders, Stream requestStream,
                                          out IMessage msg, out ITransportHeaders responseHeaders,
                                          out Stream responseStream)
   {
      sinkStack.Push(this, null);
      ServerProcessing processing =
      nextServerSink.ProcessMessage(sinkStack, requestMsg, requestHeaders, requestStream, out msg,
                                    out responseHeaders, out responseStream);

      switch (processing)
      {
         case ServerProcessing.Complete:
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
                                    IMessage msg, ITransportHeaders headers, Stream stream)
   {
         sinkStack.AsyncProcessResponse(msg, headers, stream);
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
         return nextServerSink;
      }
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
