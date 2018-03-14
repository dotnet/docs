/// Class: System.Runtime.Remoting.Channels.Ipc.IpcServerChannel
/// 41 #ctor(IDictionary,IServerChannelSinkProvider)
/// 42 #ctor(String,String)
/// 43 #ctor(String,String,IServerChannelSinkProvider)

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;

public class Server
{
    public static IpcServerChannel Ctor1()
    {
        //<snippet41>
        // Create the server channel.
        System.Collections.IDictionary properties = 
            new System.Collections.Hashtable();
        properties["name"] = "ipc";
        properties["priority"] = "20";
        properties["portName"] = "localhost:9090";
        IpcServerChannel serverChannel = 
            new IpcServerChannel(properties, null); 
        //</snippet41>

        return serverChannel;
    }

    public static IpcServerChannel Ctor2()
    {
        //<snippet42>
        // Create the server channel.
        string name = "ipc";
        string portName = "localhost:9090";
        IpcServerChannel serverChannel = 
            new IpcServerChannel(name, portName);
        //</snippet42>

        return serverChannel;
    }

    public static IpcServerChannel Ctor3()
    {
        //<snippet43>
        // Create the server channel.
        string name = "ipc";
        string portName = "localhost:9090";
        IServerChannelSinkProvider sinkProvider = null;
        IpcServerChannel serverChannel = 
            new IpcServerChannel(name, portName, sinkProvider);
        //</snippet43>

        return serverChannel;
    }

[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        // Create the server channel.
        IpcServerChannel serverChannel = null;
        if (false) { }
        else if (args[0] == "1") serverChannel = Ctor1();
        else if (args[0] == "2") serverChannel = Ctor2();
        else if (args[0] == "3") serverChannel = Ctor3();
        else throw new ApplicationException("Invalid argument.");

        // Register the server channel.
        ChannelServices.RegisterChannel(serverChannel);

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(RemoteObject), "RemoteObject.rem", 
            WellKnownObjectMode.Singleton);

        // Show the URIs associated with the channel.
        ChannelDataStore channelData = 
            (ChannelDataStore) serverChannel.ChannelData;
        foreach (string uri in channelData.ChannelUris)
        {
            Console.WriteLine("The channel URI is {0}.", uri);
        }

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}
