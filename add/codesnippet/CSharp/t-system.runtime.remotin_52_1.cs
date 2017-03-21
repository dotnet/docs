using System;
using System.Collections;
using System.IO;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;

public class ClientSink : BaseChannelSinkWithProperties, IClientChannelSink
{

    // This class inherits from BaseChannelSinkWithPropertes
    // to get an implementation of IChannelSinkBase.


    // The next sink in the chain.
    private IClientChannelSink nextSink;

    public IClientChannelSink NextChannelSink
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get
        {
            return(nextSink);
        }
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public Stream GetRequestStream (IMessage message, ITransportHeaders requestHeaders)
    {
        // Get the request stream from the next sink in the chain.
        return( nextSink.GetRequestStream(message, requestHeaders) );
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void ProcessMessage (IMessage message,
                                ITransportHeaders requestHeaders,
                                Stream requestStream,
                                out ITransportHeaders responseHeaders,
                                out Stream responseStream)
    {
        // Print the request message properties.
        Console.WriteLine("---- Message from the client ----");
        IDictionary dictionary = message.Properties;
        foreach (Object key in dictionary.Keys)
        {
            Console.WriteLine("{0} = {1}", key, dictionary[key]);
        }
        Console.WriteLine("---------------------------------");

        // Hand off to the next sink in the chain.
        nextSink.ProcessMessage(message, requestHeaders, requestStream, out responseHeaders, out responseStream);
    } 

    // For synchronous remoting, it is not necessary to implement this method.
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void AsyncProcessRequest (IClientChannelSinkStack sinkStack,
                                     IMessage message,
                                     ITransportHeaders requestHeaders,
                                     Stream requestStream)
    {
        throw new NotImplementedException();
    }

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void AsyncProcessResponse (IClientResponseChannelSinkStack sinkStack,
                                      Object state,
                                      ITransportHeaders responseHeaders,
                                      Stream responseStream)
    {
        throw new NotImplementedException();
    }


    // Constructor
    [SecurityPermission(SecurityAction.LinkDemand)]
    public ClientSink (IClientChannelSink sink) {
      if (sink == null) throw new ArgumentNullException("sink");
      nextSink = sink;
    }

}