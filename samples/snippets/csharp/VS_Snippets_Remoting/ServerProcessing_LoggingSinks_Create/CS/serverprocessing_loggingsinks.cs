// System.Runtime.Remoting.Channels.IClientChannelSinkProvider.CreateSink()
// System.Runtime.Remoting.Channels.IClientChannelSinkProvider.Next
// System.Runtime.Remoting.Channels.ServerProcessing
// System.Runtime.Remoting.Channels.ServerProcessing.Complete
// System.Runtime.Remoting.Channels.ServerProcessing.OneWay
// System.Runtime.Remoting.Channels.ServerProcessing.Async

/* The following program demonstrates the 'CreateSink()' method and 'Next'
   property of 'System.Runtime.Remoting.Channels.IClientChannelSinkProvider' interface.
   This program also demonstrates the
   'System.Runtime.Remoting.Channels.ServerProcessing' enum and its
   members 'Complete','OneWay' and 'Async'. This example defines two classes
   one for Client logging and other for Server based logging.
   Client Requests are sent to the server and the same is reflected
   in terms of Responses on the server end.The incoming message from the
   client is proccessed and is handled by the 'ServerProcessing'
   enum. The output of the 'ServerProcessing' enum is displayed
   on the server console.
*/

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata;
using System.Security.Permissions;

namespace MyLogging
{
// <Snippet1>
// <Snippet2>
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyServerProcessingLogClientChannelSinkProviderData : IClientChannelSinkProvider
   {

      private IClientChannelSinkProvider myClientChannelSinkProviderNext = null;
      public MyServerProcessingLogClientChannelSinkProviderData()
      {
      }
      public MyServerProcessingLogClientChannelSinkProviderData(IDictionary myIDictionaryProperties,
                                                                  ICollection myICollectionProviderData)
      {
      }

      public IClientChannelSink CreateSink(IChannelSender myChannelSenderData, String url,
         Object myRemoteChannelData)
      {
         IClientChannelSink myClientChannelSinkNextSink = null;
         if (myClientChannelSinkProviderNext != null)
         {
            myClientChannelSinkNextSink =
               myClientChannelSinkProviderNext.CreateSink(myChannelSenderData, url, myRemoteChannelData);
            if (myClientChannelSinkNextSink == null)
               return null;
         }
         return new MyLoggingClientChannelSink(myClientChannelSinkNextSink);
      }

      public IClientChannelSinkProvider Next
      {
         get
            {
               return myClientChannelSinkProviderNext;
            }
         set
            {
                myClientChannelSinkProviderNext = value;
            }
      }
   }
// </Snippet2>
// </Snippet1>
   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   internal class MyLoggingClientChannelSink : BaseChannelObjectWithProperties, IClientChannelSink,
      ILoggingSink
   {
      private IClientChannelSink myNewNextSink = null;
      private bool myBoolEnabled = true;
      private TextWriter myTextWriterOutput = Console.Out;

      public MyLoggingClientChannelSink(IClientChannelSink myClientChannelSinkNextSink) : base()
      {
         myNewNextSink = myClientChannelSinkNextSink;
      }

      public MyLoggingClientChannelSink(IChannelSender myChannelSenderData, String url, Object myRemoteChannelData,
         IClientChannelSink myClientChannelSinkNextSink) : base()
      {
         myNewNextSink = myClientChannelSinkNextSink;
      }

      public void ProcessMessage(IMessage msg,
         ITransportHeaders requestHeaders, Stream requestStream,
         out ITransportHeaders responseHeaders, out Stream responseStream)
      {
         if (myBoolEnabled)
            LoggingHelper.PrintRequest(myTextWriterOutput, requestHeaders, ref requestStream);

         myNewNextSink.ProcessMessage(msg, requestHeaders, requestStream,
            out responseHeaders, out responseStream);

         if (myBoolEnabled)
            LoggingHelper.PrintResponse(myTextWriterOutput, responseHeaders, ref responseStream);
      }

      public void AsyncProcessRequest(IClientChannelSinkStack myClientChannelSinkStack, IMessage msg,
         ITransportHeaders headers, Stream stream)
      {
      }

      public void AsyncProcessResponse(IClientResponseChannelSinkStack myClientChannelSinkStack, Object state,
         ITransportHeaders headers, Stream stream)
      {
      }

      public Stream GetRequestStream(IMessage msg, ITransportHeaders headers)
      {
         return null;
      }

      public IClientChannelSink NextChannelSink
      {
         get { return myNewNextSink; }
      }

      public bool Enabled
      {
         get 
            { 
               return myBoolEnabled;   
             }
         set 
            {
               myBoolEnabled = value; 
             }
      }

      public TextWriter Out
      {
         set { myTextWriterOutput = value; }
      }

      public override Object this[Object key]
      {
         get
         {
            if (key == typeof(LoggingSinkKey))
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
            ArrayList myArrayListKeys = new ArrayList(1);
            myArrayListKeys.Add(typeof(LoggingSinkKey));
            return myArrayListKeys;
         }
      }
   }

   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   public class MyServerProcessingLogServerChannelSinkProviderData : IServerChannelSinkProvider
   {
      private IServerChannelSinkProvider myServerChannelSinkProviderNext = null;

      public MyServerProcessingLogServerChannelSinkProviderData()
      {
      }

      public MyServerProcessingLogServerChannelSinkProviderData(IDictionary myIDictionaryProperties, ICollection myICollectionProviderData)
      {
      }

      public void GetChannelData(IChannelDataStore channelData)
      {
      }

      public IServerChannelSink CreateSink(IChannelReceiver myChannelReceiverData)
      {
         IServerChannelSink myServerChannelSinkNextSink = null;
         if (myServerChannelSinkProviderNext != null)
            myServerChannelSinkNextSink = myServerChannelSinkProviderNext.CreateSink(myChannelReceiverData);
         return new LoggingServerChannelSink(myServerChannelSinkNextSink);
      }

      public IServerChannelSinkProvider Next
      {
         get { return myServerChannelSinkProviderNext; }
         set { myServerChannelSinkProviderNext = value; }
      }
   }

   [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
   internal class LoggingServerChannelSink : BaseChannelObjectWithProperties, IServerChannelSink,
      ILoggingSink
   {
      private IServerChannelSink myNewNextSink = null;
      private bool       myBoolEnabled = true;
      private TextWriter myTextWriterOutput = Console.Out;

      public LoggingServerChannelSink(IServerChannelSink myServerChannelSinkNextSink) : base()
      {
         myNewNextSink = myServerChannelSinkNextSink;
      }

      public LoggingServerChannelSink(IChannelReceiver myChannelReceiverData,
         IServerChannelSink myServerChannelSinkNextSink) : base()
      {
         myNewNextSink = myServerChannelSinkNextSink;
      }

// <Snippet3>
      public ServerProcessing ProcessMessage(IServerChannelSinkStack myServerChannelSinkStack,
         IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream,
         out IMessage msg, out ITransportHeaders responseHeaders,
         out Stream responseStream)
      {
         if (myBoolEnabled)
            LoggingHelper.PrintRequest(myTextWriterOutput, requestHeaders, ref requestStream);

         myServerChannelSinkStack.Push(this, null);
// <Snippet4>
// <Snippet5>
// <Snippet6>
         ServerProcessing myServerProcessing =
            myNewNextSink.ProcessMessage(myServerChannelSinkStack, requestMsg, requestHeaders, requestStream, out msg,
            out responseHeaders, out responseStream);

         Console.WriteLine("ServerProcessing.Complete value is:   " +ServerProcessing.Complete);
         Console.WriteLine("ServerProcessing.OneWay Value is:     " +ServerProcessing.OneWay);
         Console.WriteLine("ServerProcessing.Async value is:      " +ServerProcessing.Async);

         switch (myServerProcessing)
         {
            case ServerProcessing.Complete:
            {
               myServerChannelSinkStack.Pop(this);
               if (myBoolEnabled)
                  LoggingHelper.PrintResponse(myTextWriterOutput, responseHeaders, ref responseStream);
               break;
            }

            case ServerProcessing.OneWay:
            {
               myServerChannelSinkStack.Pop(this);
               break;
            }

            case ServerProcessing.Async:
            {
               myServerChannelSinkStack.Store(this, null);
               break;
            }
         }
         return myServerProcessing;
// </Snippet6>
// </Snippet5>
// </Snippet4>
      }
// </Snippet3>

      public void AsyncProcessResponse(IServerResponseChannelSinkStack myServerChannelSinkStack, Object state,
         IMessage msg, ITransportHeaders headers, Stream stream)
      {
      }

      public Stream GetResponseStream(IServerResponseChannelSinkStack myServerChannelSinkStack, Object state,
         IMessage msg, ITransportHeaders headers)
      {
         return null;
      }

      public IServerChannelSink NextChannelSink
      {
         get { return myNewNextSink; }
      }

      public bool Enabled
      {
         get { return myBoolEnabled; }
         set { myBoolEnabled = value; }
      }

      public TextWriter Out
      {
         set { myTextWriterOutput = value; }
      }

      public override Object this[Object key]
      {
         get
         {
            if (key == typeof(LoggingSinkKey))
            {
               return this;
            }

            else
            {
               return null;
            }
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
            ArrayList myArrayListKeys = new ArrayList(1);
            myArrayListKeys.Add(typeof(LoggingSinkKey));
            return myArrayListKeys;
         }
      }
   }

   internal class LoggingHelper
   {
      internal static void PrintRequest(TextWriter output,
         ITransportHeaders requestHeaders, ref Stream requestStream)
      {
         output.WriteLine("----------Request Headers-----------");
         PrintHeaders(output, requestHeaders);

         // Print request message.
         String contentType = requestHeaders["Content-Type"] as String;
         if ((contentType != null) && contentType.StartsWith("text"))
         {
            output.WriteLine("----------Request Message-----------");
            PrintStream(output, ref requestStream);
            output.WriteLine("------End of Request Message--------");
         }
         output.Flush();
      }

      internal static void PrintResponse(TextWriter output,
         ITransportHeaders responseHeaders, ref Stream responseStream)
      {
         output.WriteLine("----------Response Headers----------");
         PrintHeaders(output, responseHeaders);

         // Print response message.
         String contentType = responseHeaders["Content-Type"] as String;
         if ((contentType != null) && contentType.StartsWith("text"))
         {
            output.WriteLine("----------Response Message----------");
            PrintStream(output, ref responseStream);
            output.WriteLine("------End of Response Message-------");
         }
         output.Flush();
      }

      private static void PrintHeaders(TextWriter output, ITransportHeaders headers)
      {
         foreach (DictionaryEntry header in headers)
         {
            output.WriteLine(header.Key + ": " + header.Value);
         }
      }

      private static void PrintStream(TextWriter output, ref Stream stream)
      {
         if (!stream.CanSeek)
            stream = CopyStream(stream);
         long startPosition = stream.Position;
         StreamReader sr = new StreamReader(stream);
         String line;
         while ((line = sr.ReadLine()) != null)
         {
            output.WriteLine(line);
         }
         stream.Position = startPosition;
      }

      private static Stream CopyStream(Stream stream)
      {
         Stream streamCopy = new MemoryStream();
         const int bufferSize = 1024;
         byte[] buffer = new byte[bufferSize];
         int readCount;
         do
         {
            readCount = stream.Read(buffer, 0, bufferSize);
            if (readCount > 0)
               streamCopy.Write(buffer, 0, readCount);
         } while (readCount > 0);

         // Close original stream.
         stream.Close();
         streamCopy.Position = 0;
         return streamCopy;
      }
   }

   public interface ILoggingSink
   {
      bool Enabled { get; set; }
      TextWriter Out { set; }
   }

   // This class is used as the key to get the ILoggingSink interface
   // to one of the logging sinks.
   public class LoggingSinkKey
   {
   }
}

