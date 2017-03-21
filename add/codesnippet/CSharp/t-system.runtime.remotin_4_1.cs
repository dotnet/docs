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

        // Display the channel's scheme.
        Console.WriteLine("The channel scheme is {0}.", 
            serverChannel.ChannelScheme);

        // Display the channel's URI.
        Console.WriteLine("The channel URI is {0}.", 
            serverChannel.GetChannelUri());

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject), "RemoteObject.rem", 
            WellKnownObjectMode.Singleton);

        // Get the channel's sink chain.
        IServerChannelSink sinkChain = serverChannel.ChannelSinkChain;
        Console.WriteLine(
            "The type of the server channel's sink chain is {0}.",
            sinkChain.GetType().ToString());

        // See if the channel wants to listen.
        bool wantsToListen = serverChannel.WantsToListen;
        Console.WriteLine(
            "The value of WantsToListen is {0}.", 
            wantsToListen);

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
        
        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}