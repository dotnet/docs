using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

public class ServerSink : BaseChannelSinkWithProperties, IServerChannelSink
{

    // This class inherits from BaseChannelSinkWithPropertes
    // to get an implementation of IChannelSinkBase.


    // The next sink in the chain.
    private IServerChannelSink nextSink;

    public IServerChannelSink NextChannelSink
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get
        {
            return(nextSink);
        }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public Stream GetResponseStream (IServerResponseChannelSinkStack sinkStack,
                                     Object state,
                                     IMessage message,
                                     ITransportHeaders responseHeaders)
    {
        return(null);
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public ServerProcessing ProcessMessage (IServerChannelSinkStack sinkStack,
                                            IMessage requestMessage,
                                            ITransportHeaders requestHeaders,
                                            Stream requestStream,
                                            out IMessage responseMessage,
                                            out ITransportHeaders responseHeaders,
                                            out Stream responseStream)
    {

        // Hand off to the next sink for processing.
        sinkStack.Push(this, null);
        ServerProcessing status = nextSink.ProcessMessage(
          sinkStack, requestMessage, requestHeaders, requestStream,
          out responseMessage, out responseHeaders, out responseStream
        );

        // Print the response message properties.
        Console.WriteLine("---- Message from the server ----");
        IDictionary dictionary = responseMessage.Properties;
        foreach (Object key in dictionary.Keys)
        {
            Console.WriteLine("{0} = {1}", key, dictionary[key]);
        }
        Console.WriteLine("---------------------------------");

        return(status);
    } 

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void AsyncProcessResponse (IServerResponseChannelSinkStack sinkStack,
                                      Object state,
                                      IMessage message,
                                      ITransportHeaders responseHeaders,
                                      Stream responseStream)
    {
        throw new NotImplementedException();
    }

    // Constructor
    [SecurityPermission(SecurityAction.LinkDemand)]
    public ServerSink (IServerChannelSink sink) {
      if (sink == null) throw new ArgumentNullException("sink");
      nextSink = sink;
    }


}