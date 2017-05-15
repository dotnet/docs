/// Legend:
/// -    Bugs
/// x    Done
///        Work in progress

/// Snippets needed: 
///    -    Ctor()
///    x    Ctor(IDictionary,IServerChannelSinkProvider)
///    x    Ctor(string,int)
///    x    Ctor(string,int,IServerChannelSinkProvider)

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Security.Permissions;

public class Server2
{
    // Broken.
[SecurityPermission(SecurityAction.Demand)]
    private static HttpServerChannel Ctor1() 
    {
        //<snippet11>
        HttpServerChannel serverChannel = new HttpServerChannel();
        serverChannel.AddHookChannelUri("http://localhost:9090");
        //</snippet11>

        // return serverChannel; 

        // Return good channel until fix.
        return Ctor2();
    }

    private static HttpServerChannel Ctor2()
    {
        //<snippet12>
        System.Collections.Hashtable properties =
            new System.Collections.Hashtable();
        properties["port"] = 9090;
        IServerChannelSinkProvider sinkProvider = null;
        HttpServerChannel serverChannel = new HttpServerChannel(
            properties, sinkProvider);
        //</snippet12>
        return serverChannel;
    }

    private static HttpServerChannel Ctor3()
    {
        //<snippet13>
        string name = "RemotingServer";
        int port = 9090;
        HttpServerChannel serverChannel = 
            new HttpServerChannel(name, port);
        //</snippet13>
        return serverChannel;
    }

    private static HttpServerChannel Ctor4()
    {
        //<snippet14>
        string name = "RemotingServer";
        int port = 9090;
        IServerChannelSinkProvider sinkProvider = null;
        HttpServerChannel serverChannel = 
            new HttpServerChannel(name, port, sinkProvider);
        //</snippet14>
        return serverChannel;
    }

    public static void Main(string[] args)
    {
        HttpServerChannel serverChannel = null;
        string overload = args[0];
        if      (overload == "1") serverChannel = Ctor1();
        else if (overload == "2") serverChannel = Ctor2();
        else if (overload == "3") serverChannel = Ctor3();
        else if (overload == "4") serverChannel = Ctor4();
        else throw new Exception("Argument " + args[0] + "was invalid.");

        // Register the server channel.
        ChannelServices.RegisterChannel(serverChannel);

        // Display the channel's URI.
        Console.WriteLine("The URI of the channel is {0}.", 
            serverChannel.GetChannelUri());

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject), "RemoteObject.rem", 
            WellKnownObjectMode.Singleton);

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}
