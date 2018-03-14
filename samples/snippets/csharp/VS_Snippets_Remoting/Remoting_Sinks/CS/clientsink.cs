// <snippet20>
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


// <snippet21>
    // The next sink in the chain.
    private IClientChannelSink nextSink;
// </snippet21>

// <snippet22>
    public IClientChannelSink NextChannelSink
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get
        {
            return(nextSink);
        }
    }
// </snippet22>

// <snippet23>
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public Stream GetRequestStream (IMessage message, ITransportHeaders requestHeaders)
    {
        // Get the request stream from the next sink in the chain.
        return( nextSink.GetRequestStream(message, requestHeaders) );
    }
// </snippet23>

// <snippet24>
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
// </snippet24>

// <snippet25>
    // For synchronous remoting, it is not necessary to implement this method.
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void AsyncProcessRequest (IClientChannelSinkStack sinkStack,
                                     IMessage message,
                                     ITransportHeaders requestHeaders,
                                     Stream requestStream)
    {
        throw new NotImplementedException();
    }
// </snippet25>

// <snippet26>
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public void AsyncProcessResponse (IClientResponseChannelSinkStack sinkStack,
                                      Object state,
                                      ITransportHeaders responseHeaders,
                                      Stream responseStream)
    {
        throw new NotImplementedException();
    }
// </snippet26>


    // Constructor
    [SecurityPermission(SecurityAction.LinkDemand)]
    public ClientSink (IClientChannelSink sink) {
      if (sink == null) throw new ArgumentNullException("sink");
      nextSink = sink;
    }

}
// </snippet20>

// <snippet30>
public class ClientSinkProvider : IClientChannelSinkProvider
{

// <snippet31>
    // The next provider in the chain.
    private IClientChannelSinkProvider nextProvider;
// </snippet31>

// <snippet32>
    public IClientChannelSinkProvider Next
    {
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        get
        {
            return(nextProvider);
        }
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        set
        {
            nextProvider = value;
        }
    }
// </snippet32>

// <snippet33>
    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
    public IClientChannelSink CreateSink (IChannelSender channel, String url, Object remoteChannelData)
    {

        Console.WriteLine("Creating ClientSink for {0}", url);

        // Create the next sink in the chain.
        IClientChannelSink nextSink = nextProvider.CreateSink(channel, url, remoteChannelData);

        // Hook our sink up to it.
        return( new ClientSink(nextSink) );
    }
// </snippet33>

    // This constructor is required in order to use the provider in file-based configuration.
    // It need not do anything unless you want to use the information in the parameters.
    public ClientSinkProvider (IDictionary properties, ICollection providerData) {}
    
}
// </snippet30>
