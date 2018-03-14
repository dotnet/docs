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

using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.Infrastructure)]
public class MyClientFormatterProvider : IClientChannelSinkProvider
{
   private IClientChannelSinkProvider nextProvider = null;
   public MyClientFormatterProvider()
   {
   }

   public IClientChannelSink CreateSink(IChannelSender channel,
                                    String myUrl, Object remoteChannelData)
   {
// <Snippet1>
      IClientChannelSink nextSink = null;
      IMessageSink nextMsgSink = null;
      if (nextProvider!=null)
      {
            Console.WriteLine("Next client sink provider is: "+
                                                         nextProvider);
            // Create a sink chain calling the next sink provider's
            // 'CreateSink' method.
            nextSink=nextProvider.CreateSink(channel,myUrl,remoteChannelData);
            nextMsgSink=(IMessageSink)nextSink;
      }
// </Snippet1>
      return new MyClientFormatterChannelSink(nextSink,nextMsgSink);
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
// <Snippet2>
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
// </Snippet2>