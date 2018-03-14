/// Class: System.Runtime.Remoting.Channels.Ipc.IpcServerChannel
/// 41 #ctor(IDictionary,IServerChannelSinkProvider)
/// 42 #ctor(String,String)
/// 43 #ctor(String,String,IServerChannelSinkProvider)
/// 15 ChannelData
/// 12 ChannelName
/// 13 ChannelPriority
/// 19 GetUrlsForUri
/// 19 Parse(String,String@)
/// !  StartListening(Object)
/// !  StopListening(Object)

using System;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security.Permissions;

public class Server
{
[SecurityPermission(SecurityAction.Demand)]
    public static void Main(string[] args)
    {
        // Create the server channel.
        IpcServerChannel serverChannel = 
            new IpcServerChannel("localhost:9090"); 

        // Register the server channel.
        System.Runtime.Remoting.Channels.ChannelServices.RegisterChannel(
            serverChannel);

        //<snippet12>
        // Show the name of the channel.
        Console.WriteLine("The name of the channel is {0}.", 
            serverChannel.ChannelName);
        //</snippet12>

        //<snippet13>
        // Show the priority of the channel.
        Console.WriteLine("The priority of the channel is {0}.", 
            serverChannel.ChannelPriority);
        //</snippet13>

        //<snippet15>
        // Show the URIs associated with the channel.
        System.Runtime.Remoting.Channels.ChannelDataStore channelData = 
            (System.Runtime.Remoting.Channels.ChannelDataStore) 
            serverChannel.ChannelData;
        foreach (string uri in channelData.ChannelUris)
        {
            Console.WriteLine("The channel URI is {0}.", uri);
        }
        //</snippet15>

        // Expose an object for remote calls.
        System.Runtime.Remoting.RemotingConfiguration.
            RegisterWellKnownServiceType(
                typeof(RemoteObject), "RemoteObject.rem", 
                System.Runtime.Remoting.WellKnownObjectMode.Singleton);
    
        //<snippet19>
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
        //</snippet19>

        // Wait for the user prompt.
        Console.WriteLine("Press ENTER to exit the server.");
        Console.ReadLine();
        Console.WriteLine("The server is exiting.");
    }
}
