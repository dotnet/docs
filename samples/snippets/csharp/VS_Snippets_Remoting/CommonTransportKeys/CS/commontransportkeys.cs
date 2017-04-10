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
using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

namespace Logging
{ 
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class LoggingClientChannelSinkProvider : IClientChannelSinkProvider
   {
      private IClientChannelSinkProvider next1 = null;
      public IClientChannelSink CreateSink(IChannelSender channel1, String url1, 
         Object remoteChannelData)
      {
         IClientChannelSink localNextSink = null;
         if (next1 != null)
         {
            localNextSink = next1.CreateSink(channel1, url1, remoteChannelData);
            if (localNextSink == null)
               return null;
         }
         return new LoggingClientChannelSink(localNextSink);
      }
      public IClientChannelSinkProvider Next
      {
         get
         {
            return next1;
         }
         set
         {
            next1 = value;
         }
      }
   }
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   internal class LoggingClientChannelSink : BaseChannelObjectWithProperties, IClientChannelSink
   {
      private IClientChannelSink nextSink1 = null;
      public LoggingClientChannelSink(IClientChannelSink localNextSink) : base()
      {
         nextSink1 = localNextSink;
      }
      public void ProcessMessage(IMessage msg,
         ITransportHeaders requestHeaders, Stream requestStream,
         out ITransportHeaders responseHeaders, out Stream responseStream)
      {
         nextSink1.ProcessMessage(msg, requestHeaders, requestStream,
            out responseHeaders, out responseStream);
      }
      public void AsyncProcessRequest(IClientChannelSinkStack sinkStack, IMessage msg,
         ITransportHeaders headers, Stream stream1)
      {
         sinkStack.Push(this, null);
         nextSink1.AsyncProcessRequest(sinkStack, msg, headers, stream1);
      }
      public void AsyncProcessResponse(IClientResponseChannelSinkStack sinkStack, Object state,
         ITransportHeaders headers, Stream stream1)
      {
         sinkStack.AsyncProcessResponse(headers, stream1);
      }
      public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
      {
         return null;
      }
      public IClientChannelSink NextChannelSink
      {
         get
         {
            return nextSink1;
         }
      }
   }
// <Snippet1>
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
// <Snippet2>
            Console.WriteLine( CommonTransportKeys.IPAddress + ":" +
               requestHeaders[CommonTransportKeys.IPAddress]);
// </Snippet2>
// <Snippet3>
            Console.WriteLine( CommonTransportKeys.ConnectionId + ":" +
               requestHeaders[CommonTransportKeys.ConnectionId]);
// </Snippet3>
// <Snippet4>
            Console.WriteLine( CommonTransportKeys.RequestUri + ":" +
               requestHeaders[CommonTransportKeys.RequestUri]);
// </Snippet4>

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
// </Snippet1>
}
