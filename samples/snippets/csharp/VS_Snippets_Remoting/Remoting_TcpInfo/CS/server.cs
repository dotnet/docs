// <snippet30>
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
 
// <snippet31>
        // Set up a server channel.
        TcpServerChannel serverChannel = new TcpServerChannel(9090);
        ChannelServices.RegisterChannel(serverChannel);    
// </snippet31>

        // Expose an object for remote calls.
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Remotable), "Remotable.rem", WellKnownObjectMode.Singleton
        );

// <snippet32>
        // Show the name and priority of the channel.
        Console.WriteLine("Channel Name: {0}", serverChannel.ChannelName);
        Console.WriteLine("Channel Priority: {0}", serverChannel.ChannelPriority);
// </snippet32>

// <snippet33>
        // Show the URIs associated with the channel.
        ChannelDataStore data = (ChannelDataStore) serverChannel.ChannelData;
        foreach (string uri in data.ChannelUris)
        {
            Console.WriteLine(uri);
        }
// </snippet33> 

        // Wait for method calls.
        Console.WriteLine("Listening...");
        Console.ReadLine();

    }

}
// </snippet30>
