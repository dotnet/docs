using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

public class Server
{
    [SecurityPermission(SecurityAction.LinkDemand)]
    public static void Main()
    {
 
        // Set up a server channel.
        TcpServerChannel serverChannel = new TcpServerChannel(9090);
        ChannelServices.RegisterChannel(serverChannel);    

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Remotable), "Remotable.rem", WellKnownObjectMode.Singleton
        );

        // Show the name and priority of the channel.
        Console.WriteLine("Channel Name: {0}", serverChannel.ChannelName);
        Console.WriteLine("Channel Priority: {0}", serverChannel.ChannelPriority);

        // Show the URIs associated with the channel.
        ChannelDataStore data = (ChannelDataStore) serverChannel.ChannelData;
        foreach (string uri in data.ChannelUris)
        {
            Console.WriteLine(uri);
        }

        // Wait for method calls.
        Console.WriteLine("Listening...");
        Console.ReadLine();

    }

}