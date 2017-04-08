// <snippet20>
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

public class Client
{
    [SecurityPermission(SecurityAction.LinkDemand)]
    public static void Main()
    {

// <snippet21>
        // Set up a client channel.
        TcpClientChannel clientChannel = new TcpClientChannel();
        ChannelServices.RegisterChannel(clientChannel);
// </snippet21>

// <snippet22>
        // Show the name and priority of the channel.
        Console.WriteLine("Channel Name: {0}", clientChannel.ChannelName);
        Console.WriteLine("Channel Priority: {0}", clientChannel.ChannelPriority);
// </snippet22>

        // Obtain a proxy for a remote object.
        RemotingConfiguration.RegisterWellKnownClientType(
            typeof(Remotable), "tcp://localhost:9090/Remotable.rem"
        );

        // Call a method on the object.
        Remotable remoteObject = new Remotable();
        Console.WriteLine( remoteObject.GetCount() );
    }

}
// </snippet20>
