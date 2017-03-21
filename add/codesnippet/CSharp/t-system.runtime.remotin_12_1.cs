using System;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;

public class Server
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        // Create the server channel.
        IpcChannel serverChannel = 
            new IpcChannel("localhost:9090"); 

        // Register the server channel.
        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(
            serverChannel);

        // Show the name of the channel.
        Console.WriteLine("The name of the channel is {0}.", 
            serverChannel.ChannelName);

        // Show the priority of the channel.
        Console.WriteLine("The priority of the channel is {0}.", 
            serverChannel.ChannelPriority);

        // Show the URIs associated with the channel.
        System.Runtime.Remoting.Channels.ChannelDataStore channelData = 
            (System.Runtime.Remoting.Channels.ChannelDataStore) 
            serverChannel.ChannelData;
        foreach (string uri in channelData.ChannelUris)
        {
            Console.WriteLine("The channel URI is {0}.", uri);
        }

        // Expose an object for remote calls.
        System.Runtime.Remoting.RemotingConfiguration.
            RegisterWellKnownServiceType(
                typeof(RemoteObject), "RemoteObject.rem", 
                System.Runtime.Remoting.WellKnownObjectMode.Singleton);
    
        // Parse the channel's URI.
        string[] urls = serverChannel.GetUrlsForUri("RemoteObject.rem");
        if (urls.Length > 0)
        {
            string objectUrl = urls[0];
            string objectUri;
            string channelUri = serverChannel.Parse(objectUrl, out objectUri);
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