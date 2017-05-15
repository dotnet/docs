/// Class: System.Runtime.Remoting.Channels.Ipc.IpcChannel
/// 41 #ctor(IDictionary,IClientChannelSinkProvider,IServerChannelSinkProvider)

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;

public class Server
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        //<snippet41>
        // Create the server channel.
        System.Collections.IDictionary properties = 
            new System.Collections.Hashtable();
        properties["name"] = "ipc";
        properties["priority"] = "20";
        properties["portName"] = "localhost:9090";
        IpcChannel serverChannel = new IpcChannel(properties, null, null); 
        //</snippet41>

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
