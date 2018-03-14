/// Class:  System.Runtime.Remoting.Channels.Http.HttpServerChannel
///    20    class - server
///    30    class - client
///    40    class - remotable object
///    12    ctor(IDictionary,IServerChannelSinkProvider)
///    13    ctor(string,int)
///    14    ctor(string,int,IServerChannelSinkProvider)
///    21    ChannelScheme
///    23    ChannelSinkChain
///    22    GetChannelUri()
///    25    Parse()
///    24    WantsToListen

///    !    Ctor()
///    !    AddHookChannelUri
///    !    Item
///    !    Keys
///    !    StartListening
///    !    StopListening


/// Bug Notes [01-26-04][Mon]
/// AddHookChannelUri does not pick up port.
/// Ctor() would be usable if AddHookChannelUri could be 
/// used to set the port later. Since it can't Ctor() is
/// also unusable. Items and Keys are unimplemented. While
/// StopListening works, StartListening does not restart
/// listening -- client fails. These two are likely to be 
/// used as a pair and are therefore unusable.


//<snippet20>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

public class Server
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        // Create the server channel.
        HttpServerChannel serverChannel = new HttpServerChannel(9090);

        // Register the server channel.
        ChannelServices.RegisterChannel(serverChannel);

        //<snippet21>
        // Display the channel's scheme.
        Console.WriteLine("The channel scheme is {0}.", 
            serverChannel.ChannelScheme);
        //</snippet21>

        //<snippet22>
        // Display the channel's URI.
        Console.WriteLine("The channel URI is {0}.", 
            serverChannel.GetChannelUri());
        //</snippet22>

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject), "RemoteObject.rem", 
            WellKnownObjectMode.Singleton);

        //<snippet23>
        // Get the channel's sink chain.
        IServerChannelSink sinkChain = serverChannel.ChannelSinkChain;
        Console.WriteLine(
            "The type of the server channel's sink chain is {0}.",
            sinkChain.GetType().ToString());
        //</snippet23>

        //<snippet24>
        // See if the channel wants to listen.
        bool wantsToListen = serverChannel.WantsToListen;
        Console.WriteLine(
            "The value of WantsToListen is {0}.", 
            wantsToListen);
        //</snippet24>

        //<snippet25>
        // Parse the channel's URI.
        string[] urls = serverChannel.GetUrlsForUri("RemoteObject.rem");
        if (urls.Length > 0)
        {
            string objectUrl = urls[0];
            string objectUri;
            string channelUri = 
                serverChannel.Parse(objectUrl, out objectUri);
            Console.WriteLine("The object URI is {0}.", objectUri);
            Console.WriteLine("The channel URI is {0}.", channelUri);
            Console.WriteLine("The object URL is {0}.", objectUrl);
        }
        //</snippet25>
        
        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}
//</snippet20>
